using Xunit;

namespace DivideAndConquer.Matrixes
{
    public class MatrixTests
    {
        private readonly BruteForce _bruteForce;

        public MatrixTests()
        {
            _bruteForce = new BruteForce();
        }

        [Fact]
        public void SimpleInput_Returns_MultiplyedMatrix()
        {
            var first = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 6, 2 },
                new int[] { 1, 6 },
            };

            var second = new int[][]
            {
                new int[] { 5, 4, 9 },
                new int[] { 6, 6, 2 },
            };

            var expected = new int[][]
            {
                new int[] { 29, 28, 17 },
                new int[] { 42, 36, 58 },
                new int[] { 41, 40, 21 },
            };

            var result = _bruteForce.Run(first, second);

            Assert.Equal(expected, result);
        }
    }
}
