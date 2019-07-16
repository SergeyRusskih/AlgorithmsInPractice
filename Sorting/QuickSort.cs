using Xunit;

namespace Sorting
{
    public class QuickSort
    {
        private void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                var pi = Partition(arr, low, high);
                Sort(arr, low, pi - 1);
                Sort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            var pivot = arr[high];

            var i = low - 1;
            for (int j = low; j < high; j++)
                if (arr[j] <= pivot)
                    Swap(ref i, j, arr);

            Swap(ref i, high, arr);

            return i;
        }

        private void Swap(ref int index, int target, int[] arr)
        {
            index++;

            if (index == target)
                return;

            var tmp = arr[target];
            arr[target] = arr[index];
            arr[index] = tmp;
        }

        [Fact]
        public void Simple_Test()
        {
            var arr = new[] { 40, 30, 10, 50, 70, 20, 80, 60 };

            Sort(arr);

            Assert.Equal(new [] { 10, 20, 30, 40, 50, 60, 70, 80 }, arr);
        }
    }
}