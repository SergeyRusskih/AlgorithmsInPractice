using Xunit;

namespace DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        private int Calculate(int[] sequence)
        {
            if (sequence.Length == 1)
                return 1;

            var result = 1;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > sequence[i - 1])
                    result++;
            }

            return result;
        }

        [Fact]
        public void LisTest()
        {
            var sequence = new[] { -7, 10, 9, 2, 3, 8, 8, 1 };
            var result = Calculate(sequence);
            Assert.Equal(4, result);
        }
    }
}
