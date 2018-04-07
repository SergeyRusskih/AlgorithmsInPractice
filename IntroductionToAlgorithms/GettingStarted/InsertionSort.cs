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
            return input;
        }
    }
}
