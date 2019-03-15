using System.Collections.Generic;
using Xunit;

namespace Graphs.Dfs
{
    public class Backtracking
    {
        public static void Run(List<int>[] matrix)
        {
            var stack = new Stack<int>();
            var visited = new bool[matrix.Length];

            var first = matrix[0];
            visited[0] = true;
            foreach (var i in first)
            {
                stack.Push(i);
            }

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var i in matrix[node])
                {
                    if (visited[i])
                        continue;

                    stack.Push(i);
                }

                visited[node] = true;
            }
        }
    }

    public class BacktrackingTests
    {
        [Fact]
        public void Test_Backtracking()
        {
            var matrix = new[]
            {
                new List<int> { 1, 2 },
                new List<int> { 0, 3, 4 },
                new List<int> { 0 },
                new List<int> { 1, 5 },
                new List<int> { 1, 5 },
                new List<int> { 3, 4 }
            };

            Backtracking.Run(matrix);
        }
    }
}
