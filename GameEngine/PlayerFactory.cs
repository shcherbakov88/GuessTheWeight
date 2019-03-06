using System;
using GameEngine.Players;

namespace GameEngine
{
    /// <summary>
    /// Represents the factory for the creation of the <see cref="Player"/> objects.
    /// </summary>
    public static class PlayerFactory
    {
        /// <summary>
        /// Creates a new <see cref="Player"/> instance.
        /// </summary>
        /// <param name="name">the name of the player.</param>
        /// <param name="type">the type of the player.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="name"/> is null, empty or contain only whitespaces.</exception>
        public static Player CreatePlayer(string name, PlayerType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The argument {nameof(name)} cannot be null, empty or contain only whitespaces.");

            switch (type)
            {
                case PlayerType.Cheater: return new CheaterPlayer(name);
                case PlayerType.Memory: return new MemoryPlayer(name);
                case PlayerType.Random: return new RandomPlayer(name);
                case PlayerType.Thorough: return new ThoroughPlayer(name);
                case PlayerType.ThoroughCheater: return new ThoroughCheaterPlayer(name);

                default: throw new Exception("Current player type is not supported.");
            }
        }
    }
}