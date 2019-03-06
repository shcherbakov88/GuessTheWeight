using System.Collections.Generic;

namespace GameEngine.Players
{
    /// <summary>
    /// Tries all numbers by order but skips numbers that were already been tried before by any of the players.
    /// </summary>
    public sealed class ThoroughCheaterPlayer : BaseThoroughPlayer
    {
        internal ThoroughCheaterPlayer(string name) : base(name)
        {
        }

        internal override int TryGuessWeight(int minValue, int maxValue, List<int> globalAttempts)
        {
            if (Counter == 0)
                Counter = minValue - 1;

            Counter++;
            while (globalAttempts.Contains(Counter))
            {
                Counter++;
            }

            return Counter;
        }
    }
}