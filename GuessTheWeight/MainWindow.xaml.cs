using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using GameEngine;
using GameEngine.Games;
using GameEngine.Players;
using GuessTheWeight.Annotations;

namespace GuessTheWeight
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public PlayerType NewPlayerType { get; set; }

        public ObservableCollection<Player> Players { get; set; }

        public GameRules GameRules { get; set; }

        public string NewPlayerName { get; set; }

        public GameResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }
        private GameResult _result;

        public MainWindow()
        {
            Players = new ObservableCollection<Player>
            {
                PlayerFactory.CreatePlayer("Marko bot", PlayerType.Memory),
                PlayerFactory.CreatePlayer("Zeus bot", PlayerType.Cheater),
                PlayerFactory.CreatePlayer("Polo bot", PlayerType.Random),
                PlayerFactory.CreatePlayer("Vanillia bot", PlayerType.Thorough),
                PlayerFactory.CreatePlayer("Mega bot", PlayerType.ThoroughCheater)
            };

            NewPlayerType = PlayerType.Cheater;
            GameRules = GameRules.DefaultGameRules;

            InitializeComponent();
        }

        private void AddNewPlayerButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewPlayerName))
            {
                MessageBox.Show("Cannot create player with no name.");
                return;
            }

            if (Players.Any(a => a.Name == NewPlayerName))
            {
                MessageBox.Show($"Player with name {NewPlayerName} has been already added.");
                return;
            }

            Players.Add(PlayerFactory.CreatePlayer(NewPlayerName, NewPlayerType));
        }

        private async void StartgameButtonClick(object sender, RoutedEventArgs e)
        {
            Result = null;
            Result = await GameFactory.CreateGame(Players.ToList()).Start(GameRules);
        }

        private void RemoveLastplayerButtonClick(object sender, RoutedEventArgs e)
        {
            Players.Remove(Players.Last());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
