using System.Collections.Generic;
using GameEngine.Games;
using GameEngine.Players;

namespace GameEngine
{
    /// <summary>
    /// Represents the factory for the creation of the <see cref="IGame"/> objects.
    /// </summary>
    public static class GameFactory
    {
        /// <summary>
        /// Creates a new game instance.
        /// </summary>
        public static IGame CreateGame()
        {
            return new Game();
        }

        /// <summary>
        /// Creates a new game instance with the specified list of players.
        /// </summary>
        /// <param name="players">The list of players.</param>
        public static IGame CreateGame(List<Player> players)
        {
            var game = new Game();

            foreach (var player in players)
            {
                game.Players.Add(player);
            }

            return game;
        }
    }
}