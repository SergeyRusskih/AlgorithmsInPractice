using Xunit;

namespace Sorting
{
    public class MergeSort
    {
        private void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int low, int high)
        {
            if (low >= high)
                return;

            var middle = (high + low) / 2;
            Sort(arr, low, middle);
            Sort(arr, middle + 1, high);
            Merge(arr, low, middle + 1, high);
        }

        private void Merge(int[] arr, int low, int middle, int high)
        {
            var tmpArr = new int[(high - low) + 1];
            var lowIndex = low;
            var middleIndex = middle;

            for (int i = 0; i < tmpArr.Length; i++)
            {
                if (lowIndex < middle && (middleIndex > high || arr[lowIndex] < arr[middleIndex]))
                {
                    tmpArr[i] = arr[lowIndex];
                    lowIndex++;
                }
                else
                {
                    tmpArr[i] = arr[middleIndex];
                    middleIndex++;
                }
            }

            var j = low;
            for (int i = 0; i < tmpArr.Length; i++)
            {
                arr[j] = tmpArr[i];
                j++;
            }
        }

        [Fact]
        public void Simple_Test()
        {
            var arr = new[] { 5, 3, 7, 8, 1, 2, 9, 4, 6 };
            Sort(arr);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, arr);
        }
    }
}