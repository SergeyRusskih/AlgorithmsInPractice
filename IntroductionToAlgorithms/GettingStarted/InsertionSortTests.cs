using Infrastructure;
using Xunit;

namespace GettingStarted
{
    public class InsertionSortTests
    {
        private readonly IExecutable<int> _sort;

        public InsertionSortTests()
        {
            _sort = new InsertionSort();
        }

        [Fact]
        public void RunSorting_WithExampleInput_ReturnsSortedSequence()
        {

        }
    }
}
