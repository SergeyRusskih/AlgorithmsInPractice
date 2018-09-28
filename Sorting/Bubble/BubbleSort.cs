namespace Sorting.Bubble
{
    /// <summary>
    ///     Bubble sort.
    /// 
    /// Popular, simple, but inefficient sorting algorithm.
    /// Complexity = O(n2)
    /// </summary>
    public class BubbleSort
    {
        public int[] Run(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
                for (var j = input.Length - 1; j > 0; j--)
                {
                    var current = input[j];
                    var previous = input[j - 1];
                    if (current < previous)
                    {
                        input[j] = previous;
                        input[j - 1] = current;
                    }
                }

            return input;
        }
    }
}
