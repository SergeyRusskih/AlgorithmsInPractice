using System;

namespace DivideAndConquer.MaximumSubarray
{
    /// <summary>
    /// Limple solution for finding max subarray problem.
    /// 
    /// Complexity - O(n)
    /// </summary>
    public class MaximumSubarrayProblemLiniar
    {
        public int[] Run(int[] input)
        {
            var resultSum = input[0];
	        var left = 0;
	        var right = 0;
	        var sum = 0;
	        var minusPos = -1;

            for (int i = 0; i < input.Length; i++) 
            {
	            sum += input[i];
 
	            if (sum > resultSum) {
		            resultSum = sum;
		            left = minusPos + 1;
		            right = i;
	            }
 
	            if (sum < 0) {
		            sum = 0;
		            minusPos = i;
	            }
            }

            var result = new int[right - left + 1];
            Array.Copy(input, left + 1, result, 0, right - left + 1);

            return result;
        }
    }
}
