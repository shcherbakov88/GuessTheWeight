using System;

namespace GameEngine.Utils
{
    internal class Validate
    {
        internal class Integer
        {
            internal static void IsLessOrEqualZero(int value, string paramName)
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(paramName);
                }
            }
        }
    }
}