using System;

namespace Miscellaneous.TravelingSalesmanBruteForce
{
    public class TravelingSalesman
    {
        public int Run(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                var visited = new bool[arr.Length];
                visited[i] = true;

                var res = RunInternal(arr, visited, i);
                min = Math.Min(res, min);
            }

            return min;
        }

        private int RunInternal(int[] arr, bool[] visited, int i)
        {
            int min = int.MaxValue;
            for (int j = 0; j < arr.Length; j++)
            {
                if (visited[j]) continue;

                var newVisited = new bool[arr.Length];
                Array.Copy(visited, newVisited, arr.Length);
                newVisited[j] = true;

                var diff = Math.Abs(arr[i] - arr[j]);
                min = Math.Min(min, diff + RunInternal(arr, newVisited, j));
            }

            return min == int.MaxValue
                ? 0
                : min;
        }
    }
}