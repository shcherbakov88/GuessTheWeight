using GameEngine.Players;

namespace GameEngine.Games
{
    /// <summary>
    /// Represents the result of the <see cref="IGame"/>.
    /// </summary>
    public class GameResult
    {
        /// <summary>
        /// Gets the game status.
        /// </summary>
        public GameStatus Status { get; internal set; }

        /// <summary>
        /// Gets the error message if the <seealso cref="Status"/> = <seealso cref="GameStatus.Failed"/>.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets the player which won the game.
        /// </summary>
        public Player Winner { get; internal set; }

        /// <summary>
        /// Gets the player whose attempt was the closest to the correct answer 
        /// if there is no winner in the game.
        /// </summary>
        public Player ClosestPlayer { get; internal set; }

        /// <summary>
        /// Gets the guess of the <see cref="ClosestPlayer"/> 
        /// if there is no winner in the game.
        /// </summary>
        public int ClosestPlayerGuess { get; internal set; }

        /// <summary>
        /// Gets the total attemts count in the game.
        /// </summary>
        public int AttemptsCount { get; internal set; }
    }
}