using Xunit;

namespace Sorting.Insertion
{
    public class InsertionSortTests
    {
        private readonly InsertionSortSequencial _sequencial;
        private readonly InsertionSortDecreasing _decreasing;

        public InsertionSortTests()
        {
            _sequencial = new InsertionSortSequencial();
            _decreasing = new InsertionSortDecreasing();
        }

        [Fact]
        public void RunSorting_WithExampleInput_ReturnsSortedSequence()
        {
            var input = new[] { 5, 2, 4, 6, 1, 3 };
            var result = _sequencial.Run(input);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [Fact]
        public void RunSorting_WithExcerciseInput_ReturnsSortedSequence()
        {
            var input = new[] { 31, 41, 59, 26, 41, 58 };
            var result = _sequencial.Run(input);
            Assert.Equal(new[] { 26, 31, 41, 41, 58, 59 }, result);
        }

        [Fact]
        public void RunSorting_WithExampleInputInDecreasingOrder_ReturnsSortedSequence()
        {
            var input = new[] { 5, 2, 4, 6, 1, 3 };
            var result = _decreasing.Run(input);
            Assert.Equal(new[] { 6, 5, 4, 3, 2, 1 }, result);
        }
    }
}
