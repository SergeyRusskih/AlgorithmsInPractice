using System;

namespace DivideAndConquer
{
    /// <summary>
    ///     Finding maximum subarray (max difference between local maximum and local minimum)
    ///     
    /// Classical case of the divide and conquer principe - we solwe the problem
    /// by recursively solwing the minumum possible case and then unite the solutions.
    /// 
    /// Complexity - O(n log n)
    /// </summary>
    public class MaximumSubarrayProblem
    {
        public int[] Run(int[] input)
        {
            // calculate differencies in the values
            var diffInput = CalculateDifferencies(input);

            var arraySlice = FindMaxSubarray(diffInput, 0, diffInput.Length - 1);

            var result = new int[arraySlice.hight - arraySlice.low + 1];
            Array.Copy(input, arraySlice.low + 1, result, 0, arraySlice.hight - arraySlice.low + 1);
            return result;
        }

        private (int low, int hight, int sum) FindMaxSubarray(int[] input, int low, int hight)
        {
            // base case, one element only
            if (low == hight)
                return (low, hight, input[low]); 

            var mid = (low + hight) / 2;

            // Thre cases are posible:
            //      - when max subarray in the left half
            //      - when max subarray in the rigth half
            //      - when max subarray crosses the halfs
            var lowSubarray = FindMaxSubarray(input, low, mid);
            var maxSubarray = FindMaxSubarray(input, mid + 1, hight);
            var crossingSubarray = FindMaxCrossingSubarray(input, low, mid, hight);

            if (lowSubarray.sum > maxSubarray.sum && lowSubarray.sum > crossingSubarray.maxSum)
                return (lowSubarray.low, lowSubarray.hight, lowSubarray.sum);

            if (maxSubarray.sum > lowSubarray.sum && maxSubarray.sum > crossingSubarray.maxSum)
                return (maxSubarray.low, maxSubarray.hight, maxSubarray.sum);

            return (crossingSubarray.maxLeft, crossingSubarray.maxRight, crossingSubarray.maxSum);
        }

        private (int maxLeft, int maxRight, int maxSum) FindMaxCrossingSubarray(int[] input, int low, int mid, int hight) 
        {
            var leftSum = int.MinValue;
            var maxLeft = 0;
            var sum = 0;

            for (var i = mid; i >= 0; i--)
            {
                sum += input[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            sum = 0;
            var rightSum = int.MinValue;
            var maxRight = 0;
            for (var j = mid + 1; j < hight; j++)
            {
                sum += input[j];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = j;
                }
            }

            var maxSum = 
                (leftSum != int.MinValue
                    ? leftSum
                    : 0) 
                    +
                (rightSum != int.MinValue
                    ? rightSum
                    : 0);

            return (maxLeft, maxRight, maxSum);
        }

        private int[] CalculateDifferencies(int[] input)
        {
            var diffInput = new int[input.Length - 1];
            for (var i = 1; i < input.Length; i++)
            {
                diffInput[i - 1] = input[i] - input[i - 1];
            }

            return diffInput;
        }
    }
}
