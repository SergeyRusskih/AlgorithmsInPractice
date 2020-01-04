namespace Sorting.Insertion
{
    /// <summary>
    ///     Insertion sort.
    /// 
    /// Efficient for sorting small number of elements.
    /// It works in a way people sort a hand of playing cards.
    /// 
    /// Complexety = O(n2)
    /// 
    /// </summary>
    public class InsertionSortSequencial
    {
        public int[] Run(int[] input)
        {
            for(var i = 1; i < input.Length; i++)
            {
                var currKey = i;
                var prevKey = i - 1;

                var currItem = input[currKey];

                while(prevKey >= 0 && input[prevKey] > currItem)
                {
                    input[prevKey + 1] = input[prevKey];
                    prevKey--;
                }

                input[prevKey + 1] = currItem;
            }

            return input;
        }

        public int[] Run1(int[] input)
        {
            if (input == null || input.Length < 2)
                return input;

            for (int i = 0; i < input.Length - 1; i++)
            {
                var key = i;
                while (key >= 0 && input[key] > input[key + 1])
                {
                    var current = input[key];
                    input[key] = input[key + 1];
                    input[key + 1] = current;
                    key--;
                }
            }

            return input;
        }
    }
}
