using System.Collections.Generic;
using System.Threading.Tasks;
using GameEngine.Players;

namespace GameEngine.Games
{
    /// <summary>
    /// Represents the game object.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Gets the list of players.
        /// </summary>
        List<Player> Players { get; }

        /// <summary>
        /// Starts the game with the <see cref="GameRules.DefaultGameRules"/> and the random answer.
        /// </summary>
        /// <returns>the task which represents the result of the game.</returns>
        Task<GameResult> Start();

        /// <summary>
        /// Starts the game with the custom game rules.
        /// </summary>
        /// <param name="gameRules">The custom game rules.</param>
        /// <returns>the task which represents the result of the game.</returns>
        Task<GameResult> Start(GameRules gameRules);
    }
}