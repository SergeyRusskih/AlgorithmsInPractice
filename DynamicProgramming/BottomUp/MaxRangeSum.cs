using System;
using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class MaxRangeSum
    {
        private int GetSubrangeSum(int[] range)
        {
            for (int i = 1; i < range.Length; i++)
            {
                range[i] += range[i - 1];
            }

            var max = int.MinValue;
            for (int i = 0; i < range.Length; i++)
            {
                var current = range[i];
                for (int j = 0; j < range.Length; j++)
                {
                    var next = range[j];
                    var toTry = current - next;
                    max = Math.Max(max, toTry);
                }
            }
            return max;
        }

        [Fact]
        public void Should_Return_Correct_Sum()
        {
            var arr = new[] { -2, -5, 6, -2, -3, 1, 5, -6 };
            var result = GetSubrangeSum(arr);
            Assert.Equal(7, result);
        }
    }
}
