namespace GettingStarted.Sort.Merge
{
    /// <summary>
    ///     Merge sort.
    ///     
    /// Uses typical "divide-and-conquer" approach:
    /// breaks the problem into several subproblems that are similar to 
    /// the original problem but smaller in size, solves the subproblems recursively,
    /// and then combine these solutions to create a solution to the original problem.
    /// 
    /// Complexety = O(n log n)
    /// 
    /// </summary>
    public class MergeSort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="index">Devides two sorted arrays</param>
        /// <returns></returns>
        public int[] Run(int[] input, int index)
        {
            var result = new int[input.Length];

            var firstKey = 0;
            var secondKey = index;
            var resultKey = 0;

            while(resultKey < result.Length)
            {
                if (secondKey >= input.Length || input[firstKey] < input[secondKey])
                {
                    result[resultKey] = input[firstKey];
                    firstKey++;
                }
                else if (firstKey < index)
                {
                    result[resultKey] = input[secondKey];
                    secondKey++;
                }

                resultKey++;
            }

            return result;
        }
    }
}
