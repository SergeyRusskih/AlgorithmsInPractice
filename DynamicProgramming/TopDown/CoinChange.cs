using System;
using Xunit;

namespace DynamicProgramming.TopDown
{
    public class CoinChange
    {
        private static int[] Coins = { 1, 5, 20 };

        private int Change(int value)
        {
            var memo = new int[value + 1];
            return Change(value, memo);
        }

        private int Change(int value, int[] memo)
        {
            if (value < 0)
                return int.MaxValue;

            if (value == 0)
                return 0;

            if (memo[value] != 0)
                return memo[value];

            var min = int.MaxValue;
            for (int i = 0; i < Coins.Length; i++)
            {
                var left = value - Coins[i];
                if (left < 0)
                    continue;

                min = Math.Min(min, Change(left, memo) + 1);
            }

            memo[value] = min;

            return min;
        }

        [Fact]
        public void Should_Change_Coins()
        {
            var result1 = Change(7);
            Assert.Equal(3, result1);

            var result2 = Change(10);
            Assert.Equal(2, result2);

            var result3 = Change(20);
            Assert.Equal(1, result3);
        }
    }
}
