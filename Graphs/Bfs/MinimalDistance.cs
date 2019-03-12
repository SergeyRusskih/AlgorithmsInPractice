using System;
using System.Collections.Generic;
using Xunit;

namespace Graphs.Bfs
{
    public class MinimalDistance
    {

        public int Run(Tuple<int, List<int>>[] matrix, int node)
        {
            var queue = new Queue<int>();
            var level = new int[matrix.Length];
            var visited = new bool[matrix.Length];

            var firstNodeIndex = matrix[0].Item1;

            queue.Enqueue(firstNodeIndex);
            level[firstNodeIndex] = 0;
            visited[firstNodeIndex] = true;

            while (queue.Count != 0)
            {
                var parent = queue.Dequeue();
                foreach (var child in matrix[parent].Item2)
                {
                    if (visited[child] == false)
                    {
                        level[child] = level[parent] + 1;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return level[node];
        }
    }

    public class MinimalDistanceTests
    {
        private readonly MinimalDistance _calculator;

        public MinimalDistanceTests()
        {
            _calculator = new MinimalDistance();
        }

        [Fact]
        public void Should_Return_Correct_Distance()
        {
            var matrix = new[]
            {
                new Tuple<int, List<int>>(0, new List<int> { 1, 2 }),
                new Tuple<int, List<int>>(1, new List<int> { 0, 2, 3 }),
                new Tuple<int, List<int>>(2, new List<int> { 0, 1, 3 }),
                new Tuple<int, List<int>>(3, new List<int> { 1, 2 })
            };

            var result = _calculator.Run(matrix, 3);

            Assert.Equal(2, result);
        }
    }
}