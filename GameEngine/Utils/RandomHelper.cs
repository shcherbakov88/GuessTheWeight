using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Utils
{
    internal static class RandomHelper
    {
        private static readonly Random Random = new Random();

        internal static int GetRandomNumber(int min, int max)
        {
            return Random.Next(min, max);
        }

        internal static int GetRandomNumberExcludingExistingNumbers(int min, int max, List<int> excludedItems)
        {
            var wholeList = Enumerable.Range(min, max - min).ToList();
            var restItems = wholeList.Except(excludedItems).ToList();
            var randomIndex = Random.Next(0, restItems.Count);
            return restItems.ElementAt(randomIndex);
        }
    }
}