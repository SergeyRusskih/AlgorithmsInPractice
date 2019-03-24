using Xunit;

namespace DynamicProgramming.TopDown
{
    public class Fibonacci
    {
        private int Calculate(int value)
        {
            var memo = new int[value + 1];
            return Calculate(value, memo);
        }

        private int Calculate(int value, int[] memo)
        {
            if (value <= 1)
                return value;

            if (memo[value] != 0)
                return memo[value];

            memo[value] = Calculate(value - 1, memo) + Calculate(value - 2, memo);
            return memo[value];
        }

        [Fact]
        public void Fibonacci_Correct()
        {
            var result = Calculate(9);
            Assert.Equal(34, result);
        }
    }
}
