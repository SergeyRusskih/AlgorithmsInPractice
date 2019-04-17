using System.Linq;
using Xunit;

namespace Graphs.MinimalSpanningTree
{
    public class Kruskals
    {
        [Fact]
        public void Should_Find_Minimal_Spanning_Tree()
        {
            var graph = new Graph();

            var a = graph.CreateNode(0);
            var b = graph.CreateNode(1);
            var c = graph.CreateNode(2);
            var d = graph.CreateNode(3);
            var e = graph.CreateNode(4);

            a.AddEdge(b, 5)
             .AddEdge(c, 5)
             .AddEdge(d, 5)
             .AddEdge(e, 5);

            b.AddEdge(c, 2);

            c.AddEdge(d, 8);

            d.AddEdge(e, 8);

            var result = Calculate(graph);
            Assert.Equal(17, result);
        }

        private int Calculate(Graph graph)
        {
            var visited = new bool[graph.AllNodes.Count];
            var edges = graph.AllNodes.SelectMany(s => s.Edges).OrderBy(s => s.Weight).ToList();

            var minPathCost = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];

                if (visited[edge.Parent.Index] && visited[edge.Child.Index])
                    continue;

                minPathCost += edge.Weight;
                visited[edge.Parent.Index] = true;
                visited[edge.Child.Index] = true;
            }

            return minPathCost;
        }
    }
}