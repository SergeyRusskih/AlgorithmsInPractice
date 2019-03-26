using System;
using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class MaxSubrectangleSum
    {
        private int FindMaxSum(int [,] rectangle)
        {
            for (int i = 0; i < rectangle.GetLength(0); i++)
            {
                for (int j = 0; j < rectangle.GetLength(1); j++)
                {
                    if (i > 0) rectangle[i, j] += rectangle[i - 1, j];
                    if (j > 0) rectangle[i, j] += rectangle[i, j - 1];
                    if (i > 0 && j > 0) rectangle[i, j] -= rectangle[i - 1, j - 1];
                }
            }

            var max = -127 * 100 * 100;
            for (int i = 0; i < rectangle.GetLength(0); i++)
            {
                for (int j = 0; j < rectangle.GetLength(1); j++)
                {
                    for (int k = i; k < rectangle.GetLength(0); k++)
                    {
                        for (int l = j; l < rectangle.GetLength(1); l++)
                        {
                            var subRect = rectangle[k, l];
                            if (i > 0) subRect -= rectangle[i - 1, l];
                            if (j > 0) subRect -= rectangle[k, j - 1];
                            if (i > 0 && j > 0) subRect += rectangle[i - 1, j - 1];

                            max = Math.Max(max, subRect);
                        }
                    }
                }
            }

            return max;
        }

        [Fact]
        public void Should_Return_Max_Sum()
        {
            var rectangle = new[,]
            {
                {  0, -2, -7,  0 },
                {  9,  2, -6,  2 },
                { -4,  1, -4,  1 },
                { -1,  8,  0, -2 }
            };

            var result = FindMaxSum(rectangle);

            Assert.Equal(15, result);
        }
    }
}
