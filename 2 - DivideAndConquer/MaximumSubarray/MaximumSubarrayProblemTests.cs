using Xunit;

namespace DivideAndConquer.MaximumSubarray
{
    public class MaximumSubarrayProblemTests
    {
        private readonly MaximumSubarrayProblem _maximumSubarray;

        public MaximumSubarrayProblemTests()
        {
            _maximumSubarray = new MaximumSubarrayProblem();
        }

        [Fact]
        public void RunMaxSliceFinding_WithExampleInput_ReturnsMaxSlice()
        {
            var input = new[] { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };
            var result = _maximumSubarray.Run(input);
            Assert.Equal(new[] { 81, 101, 94, 106 }, result);
        }

        [Fact]
        public void RunMaxSliceFinding_WithNegativeInput_ReturnsEmptyArray()
        {
            var input = new[] { 10, 9, 8, 7 };
            var result = _maximumSubarray.Run(input);
            Assert.Equal(new int[0], result);
        }
    }
}
