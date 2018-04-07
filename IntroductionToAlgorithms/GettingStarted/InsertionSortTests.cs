using Infrastructure;
using Xunit;

namespace GettingStarted
{
    public class InsertionSortTests
    {
        private readonly IRunable<int> _sort;

        public InsertionSortTests()
        {
            _sort = new InsertionSort();
        }

        [Fact]
        public void RunSorting_WithExampleInput_ReturnsSortedSequence()
        {
            var input = new[] { 5, 2, 4, 6, 1, 3 };
            var result = _sort.Run(input);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }
    }
}
