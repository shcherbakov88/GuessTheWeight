using System.Collections.Generic;
using GameEngine.Utils;

namespace GameEngine.Players
{
    /// <summary>
    /// Guesses a random number, but doesn’t try any of the numbers that other players had already tried.
    /// </summary>
    public sealed class CheaterPlayer : Player
    {
        internal CheaterPlayer(string name) : base(name)
        {
        }

        internal override int TryGuessWeight(int minValue, int maxValue, List<int> globalAttempts)
        {
            return RandomHelper.GetRandomNumberExcludingExistingNumbers(minValue, maxValue, globalAttempts);
        }
    }
}