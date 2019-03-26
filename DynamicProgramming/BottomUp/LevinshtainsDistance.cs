using System;
using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class LevinshtainsDistance
    {
        private int GetDistance(string first, string second)
        {
            var matrix = new int[first.Length + 1, second.Length + 1];

            for (int i = 0; i <= first.Length; i++)
            {
                matrix[i, 0] = i;
            }

            for (int i = 0; i <= second.Length; i++)
            {
                matrix[0, i] = i;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    var remove = matrix[i - 1, j] + 1;
                    var add = matrix[i, j - 1] + 1;
                    var replace = first[i - 1] == second[j - 1]
                        ? matrix[i - 1, j - 1]
                        : matrix[i - 1, j - 1] + 1;

                    matrix[i, j] = Math.Min(Math.Min(remove, add), replace);
                }
            }

            return matrix[first.Length, second.Length];
        }

        [Fact]
        public void Find_Distance()
        {
            var first = "saturday";
            var second = "sunday";

            var distance = GetDistance(first, second);

            Assert.Equal(3, distance);
        }
    }
}
