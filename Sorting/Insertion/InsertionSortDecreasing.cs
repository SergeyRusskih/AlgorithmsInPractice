namespace Sorting.Insertion
{
    public class InsertionSortDecreasing
    {
        public int[] Run(int[] input)
        {
            for(var i = input.Length - 2; i >= 0; i--)
            {
                var currKey = i;
                var prevKey = i + 1;

                var currItem = input[currKey];

                while(prevKey < input.Length && input[prevKey] > currItem)
                {
                    input[prevKey - 1] = input[prevKey];
                    prevKey++;
                }

                input[prevKey - 1] = currItem;
            }

            return input;
        }
    }
}
