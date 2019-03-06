using System.ComponentModel;

namespace GameEngine.Games
{
    /// <summary>
    /// Represents the result status of the game.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// Game failed.
        /// </summary>
        [Description("Failed")]
        Failed,

        /// <summary>
        /// The game was completed with the winner.
        /// </summary>
        [Description("Finished")]
        Finished,

        /// <summary>
        /// The game was stopped by <see cref="GameRules.Timeout"/>.
        /// </summary>
        [Description("Timout reached")]
        TimeotReached,

        /// <summary>
        /// The game was stopped by <see cref="GameRules.TurnsCount"/>.
        /// </summary>
        [Description("Maximum attempts count reached")]
        TurnsCountReached
    }
}