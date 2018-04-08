namespace GettingStarted
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
    }
}
