using Infrastructure;

namespace GettingStarted
{
    /// <summary>
    ///     Insertion sort.
    /// 
    /// Efficient for sorting small number of elements.
    /// It works in a way people sort a hand of 
    /// playing cards.
    /// 
    /// </summary>
    public class InsertionSort : IRunable<int>
    {
        public int[] Run(int[] input)
        {
            for (var i = 1; i < input.Length; i++)
            {
                var current = input[i];
                var cursor = i - 1;

                while (cursor >= 0 && input[cursor] > current)
                {
                    input[cursor + 1] = input[cursor];
                    cursor--;
                }

                input[cursor + 1] = current;
            }

            return input;
        }
    }
}
