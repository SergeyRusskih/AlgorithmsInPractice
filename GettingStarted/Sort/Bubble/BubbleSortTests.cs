using Xunit;

namespace GettingStarted.Sort.Bubble
{
    public class BubbleSortTests
    {
        private readonly BubbleSort _sort;

        public BubbleSortTests()
        {
            _sort = new BubbleSort();
        }

        [Fact]
        public void RunSorting_WithSimpleInput_ReturnsSortedOutput()
        {
            var input = new[] { 5, 2, 4, 6, 1, 3 };
            var result = _sort.Run(input);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }
    }
}