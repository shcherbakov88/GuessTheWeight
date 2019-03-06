using System.Collections.Generic;
using System.Linq;
using GameEngine.Utils;

namespace GameEngine.Players
{
    /// <summary>
    /// Guesses a random number but doesn’t try the same number more than once.
    /// </summary>
    public sealed class MemoryPlayer : Player
    {
        internal MemoryPlayer(string name) : base(name)
        {
        }

        internal override int TryGuessWeight(int minValue, int maxValue, List<int> globalAttempts)
        {
            return RandomHelper.GetRandomNumberExcludingExistingNumbers(minValue, maxValue, Attempts.ToList());
        }
    }
}