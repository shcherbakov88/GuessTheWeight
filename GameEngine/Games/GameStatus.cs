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
        Failed,

        /// <summary>
        /// The game was completed with the winner.
        /// </summary>
        Finished,

        /// <summary>
        /// The game was stopped by <see cref="GameRules.Timeout"/>.
        /// </summary>
        TimeotReached,

        /// <summary>
        /// The game was stopped by <see cref="GameRules.TurnsCount"/>.
        /// </summary>
        TurnsCountReached
    }
}