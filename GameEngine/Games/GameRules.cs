using System;
using GameEngine.Utils;

namespace GameEngine.Games
{
    /// <summary>
    /// Represents the rules for the game.
    /// </summary>
    public class GameRules
    { 
        private const int DefaultMinWeight = 40;
        private const int DefaultMaxWeight = 140;
        private const int DefaultTurnsCount = 100;
        private const int DefaultTimeout = 1500;

        /// <summary>
        /// Gets the correct answer.
        /// </summary>
        public int Answer { get; set; }

        /// <summary>
        /// Gets the minimum weight of the basket.
        /// </summary>
        public int MinWeight { get; set; }

        /// <summary>
        /// Gets the maximum weight of the basket.
        /// </summary>
        public int MaxWeight { get; set; }

        /// <summary>
        /// Gets the number of turns within the game should be finished.
        /// </summary>
        public int TurnsCount { get; set; }

        /// <summary>
        /// Gets the timeout in milliseconds within the game should be finished.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets the default game rules with the random answer.
        /// </summary>
        public static GameRules DefaultGameRules
        {
            get
            {
                var answer = RandomHelper.GetRandomNumber(DefaultMinWeight, DefaultMaxWeight);
                return new GameRules
                {
                    Answer = answer,
                    Timeout = DefaultTimeout,
                    MaxWeight = DefaultMaxWeight,
                    MinWeight = DefaultMinWeight,
                    TurnsCount = DefaultTurnsCount
                };
            }
        }

        internal void Validate()
        {
            const string zeroIntegerMessage = "The {0} cannot be less or equal to zero.";

            if (Answer <= 0)
                throw new Exception(string.Format(zeroIntegerMessage, "answer"));

            if (MinWeight <= 0)
                throw new Exception(string.Format(zeroIntegerMessage, "min weight"));

            if (MaxWeight <= 0)
                throw new Exception(string.Format(zeroIntegerMessage, "max weight"));

            if (TurnsCount <= 0)
                throw new Exception(string.Format(zeroIntegerMessage, "turns count"));

            if (Timeout == 0)
                throw new Exception("The timeout cannot be zero.");

            if (MaxWeight < MinWeight)
                throw new Exception("The max weight cannot be less than min weight.");

            if (Answer < MinWeight || Answer > MaxWeight)
                throw new Exception("The answer is out of range.");
        }
    }
}