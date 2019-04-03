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
            if (cuts == 1)
                return stick;

            if (cuts < 1 || stick < 2)
                return int.MaxValue - 1001 * 50;

            if (memo[stick] != 0)
                return memo[stick];

            var minCost = int.MaxValue - 1001 * 50;
            for (int i = 1; i < stick; i++)
            {
                minCost = Math.Min(
                    minCost,
                    stick
                    + FindMinimalCutCost(i, cuts - 2, memo)
                    + FindMinimalCutCost(stick - i, cuts - 2, memo));
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
