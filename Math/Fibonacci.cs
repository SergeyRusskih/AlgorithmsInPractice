using Xunit;

namespace Math
{
    public class Fibonacci
    {
        [Fact]
        public void Fibonacci_Correct()
        {
            var result = Calculate(9);
            Assert.Equal(34, result);
        }

        private int Calculate(int value)
        {
            switch (value)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Calculate(0, 1, --value);
            }
        }

        private int Calculate(int prev, int current, int goal)
        {
            if (goal == 0)
                return current;

            return Calculate(current, prev + current, --goal);
        }
    }
}