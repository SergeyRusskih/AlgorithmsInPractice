using Xunit;

namespace GettingStarted.Sort.Merge
{
    public class MergeSortTests
    {
        private readonly MergeSort _sort;

        public MergeSortTests()
        {
            _sort = new MergeSort();
        }

        [Fact]
        public void RunSorting_WithSimpleInput_ReturnsSortedOutput()
        {
            var input = new[] { 1, 5, 6, 8, 15, 2, 3, 7, 10, 11, 12 };
            var result = _sort.Run(input, 5);
            Assert.Equal(new[] { 1, 2, 3, 5, 6, 7, 8, 10, 11, 12, 15}, result);
        }
    }
}
