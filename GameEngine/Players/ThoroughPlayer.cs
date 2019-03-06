using System.Collections.Generic;

namespace GameEngine.Players
{
    /// <summary>
    /// Tries all numbers by order.
    /// </summary>
    public sealed class ThoroughPlayer : BaseThoroughPlayer
    {
        internal ThoroughPlayer(string name) : base(name)
        {
        }

        internal override int TryGuessWeight(int minValue, int maxValue, List<int> actualAttempts)
        {
            if (Counter == 0)
                Counter = minValue - 1;           

            Counter++;

            return Counter;
        }
    }
}