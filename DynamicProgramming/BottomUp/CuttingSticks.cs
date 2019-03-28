using System;
using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class CuttingSticks
    {
        private int FindMinimalCutCost(int stick, int cuts)
        {
            var memo = new int[stick + 1];
            return FindMinimalCutCost(stick, cuts, memo);
        }

        private int FindMinimalCutCost(int stick, int cuts, int[] memo)
        {
            if (cuts == 0)
                return 0;

            if (stick < 2)
                return int.MaxValue - 1001 * 50;

            if (memo[stick] != 0)
                return memo[stick];

            var minCost = int.MaxValue - 1001 * 50;
            for (int i = 1; i < (stick / 2 + 1); i++)
            {
                minCost = Math.Min(minCost, stick + FindMinimalCutCost(stick - i, cuts - 1, memo));
            }

            memo[stick] = minCost;
            return minCost;
        }

        [Fact]
        public void Should_Find_Minimal_Cost()
        {
            var stick = 100;
            var cuts = 3;

            var result = FindMinimalCutCost(stick, cuts);

            Assert.Equal(200, result);
        }
    }
}
