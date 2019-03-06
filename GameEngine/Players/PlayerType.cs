using System.ComponentModel;

namespace GameEngine.Players
{
    /// <summary>
    /// Represents the type of the player.
    /// </summary>
    public enum PlayerType
    {
        /// <summary>
        /// Cheater player.
        /// </summary>
        [Description("Cheater")]
        Cheater,

        /// <summary>
        /// Memory player.
        /// </summary>
        [Description("Memory")]
        Memory,

        /// <summary>
        /// Random player.
        /// </summary>
        [Description("Random")]
        Random,

        /// <summary>
        /// Thorough player.
        /// </summary>
        [Description("Thorough")]
        Thorough,

        /// <summary>
        /// Thorough cheater player.
        /// </summary>
        [Description("Thorough cheater")]
        ThoroughCheater
    }
}