using Xunit;

namespace Math
{
    public class GcdLcm
    {
        private int FindGcd(int first, int second)
        {
            if (second == 0)
                return first;

            return FindGcd(second, first % second);
        }

        private int FindLcm(int first, int second)
        {
            return first * (second / FindGcd(first, second));
        }

        [Theory]
        [InlineData(4, 8, 4)]
        [InlineData(10, 5, 5)]
        [InlineData(20, 12, 4)]
        public void Should_Have_Gcd(int first, int second, int expected)
        {
            var result = FindGcd(first, second);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 8, 8)]
        [InlineData(10, 5, 10)]
        [InlineData(20, 12, 60)]
        public void Should_Have_Lcm(int first, int second, int expected)
        {
            var result = FindLcm(first, second);
            Assert.Equal(expected, result);
        }
    }
}
