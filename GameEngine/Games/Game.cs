using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GameEngine.Players;

namespace GameEngine.Games
{
    internal class Game : IGame
    {
        private const int MinPlayersQuantity = 2;
        private const int MaxPlayersQuantity = 8;

        private GameRules _gameRules;

        private readonly List<int> _commonAttempts = new List<int>();

        private readonly TaskFactory _taskFactory =
            new TaskFactory(new ConcurrentExclusiveSchedulerPair().ExclusiveScheduler);

        private Task<GameResult> _currentGame;

        internal CancellationTokenSource CancellationToken;

        public List<Player> Players { get; }

        internal Game()
        {
            Players = new List<Player>();
        }

        public Task<GameResult> Start()
        {
            return StartGame(GameRules.DefaultGameRules);
        }

        public Task<GameResult> Start(GameRules gameRules)
        {
            return StartGame(gameRules);
        }

        private Task<GameResult> StartGame(GameRules gameRules)
        {
            try
            {
                ValidateGameAndRules(gameRules);
            }
            catch (Exception e)
            {
                return Task.FromResult(new GameResult
                {
                    Status = GameStatus.Failed,
                    ErrorMessage = e.Message
                });
            }

            PrepareForStart(gameRules);

            _currentGame = Task.Run(async () =>
            {
                using (CancellationToken = new CancellationTokenSource())
                {
                    CancellationToken.CancelAfter(_gameRules.Timeout);

                    var plays = new List<Task>();

                    foreach (var player in Players)
                    {
                        var play = Task.Run(async () =>
                            {
                                while (!CancellationToken.IsCancellationRequested)
                                {
                                    var delay = await MakeTurn(player);

                                    await Task.Delay(TimeSpan.FromMilliseconds(delay));
                                }
                            }, CancellationToken.Token)
                            .ContinueWith(task => { });

                        plays.Add(play);
                    }

                    await Task.WhenAll(plays);

                    return GetGameResults();
                }
            });

            return _currentGame;
        }

        internal Task<int> MakeTurn(Player player)
        {
            return _taskFactory.StartNew(() =>
            {
                if (CancellationToken.IsCancellationRequested)
                {
                    return 0;
                }

                if (_commonAttempts.Count == _gameRules.TurnsCount)
                {
                    CancellationToken.Cancel();
                    return 0;
                }

                var answer = player.TryGuessWeight(_gameRules.MinWeight, _gameRules.MaxWeight, _commonAttempts);
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Send,
                    new Action(() => player.Attempts.Add(answer)));

                _commonAttempts.Add(answer);

                var difference = Math.Abs(answer - _gameRules.Answer);
                var isCorrect = difference == 0;
                if (isCorrect)
                {
                    CancellationToken.Cancel();
                }

                return difference;
            });
        }

        private GameResult GetGameResults()
        {
            var winner = Players.FirstOrDefault(f => f.Attempts.Any(a => a == _gameRules.Answer));
            if (winner != null)
            {
                return new GameResult
                {
                    Status = GameStatus.Finished,
                    Winner = winner,
                    AttemptsCount = _commonAttempts.Count
                };
            }

            Player closestPlayer = null;
            var closestAttempt = 0;
            foreach (var player in Players)
            {
                var playerClosestAttempt = player.Attempts.OrderBy(item => Math.Abs(_gameRules.Answer - item)).First();
                if (Math.Abs(playerClosestAttempt - _gameRules.Answer) <
                    Math.Abs(closestAttempt - _gameRules.Answer))
                {
                    closestAttempt = playerClosestAttempt;
                    closestPlayer = player;
                }
            }

            return new GameResult
            {
                Status = _commonAttempts.Count == _gameRules.TurnsCount
                    ? GameStatus.TurnsCountReached
                    : GameStatus.TimeotReached,
                ClosestPlayer = closestPlayer,
                ClosestPlayerGuess = closestAttempt
            };
        }

        private void ValidateGameAndRules(GameRules rules)
        {
            if (_currentGame != null && !_currentGame.IsCompleted)
                throw new InvalidOperationException("The current game hasn't been completed yet.");

            var playersCount = Players.Count;

            if (playersCount == 0)
                throw new InvalidOperationException("The game cannot be started without players.");

            if (playersCount > MaxPlayersQuantity)
                throw new InvalidOperationException($"Too much players. Maximum quantity is {MaxPlayersQuantity}");

            if (playersCount < MinPlayersQuantity)
                throw new InvalidOperationException(
                    $"There is no enough players. Minimum quantity is {MinPlayersQuantity}");

            rules.Validate();
        }

        private void PrepareForStart(GameRules rules)
        {
            _commonAttempts.Clear();
            _gameRules = rules;

            foreach (var player in Players)
            {
                player.PrepareForTheNextGame();
            }
        }
    }
}