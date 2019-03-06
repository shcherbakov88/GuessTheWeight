using System.Collections.Generic;
using GameEngine.Utils;

namespace GameEngine.Players
{
    /// <summary>
    /// Guesses a random number.
    /// </summary>
    public sealed class RandomPlayer : Player
    {
        internal RandomPlayer(string name) : base(name)
        {
        }

        internal override int TryGuessWeight(int minValue, int maxValue, List<int> actualAttempts)
        {
            return RandomHelper.GetRandomNumber(minValue, maxValue);
        }
    }
}