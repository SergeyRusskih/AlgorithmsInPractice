using Xunit;

namespace Graphs.MinimalPath
{
    public class BellmanFord
    {
        [Fact]
        public void Should_Find_Shortest_Path()
        {
            var graph = new Graph();

            var zero = graph.CreateNode(0);
            var one = graph.CreateNode(1);
            var two = graph.CreateNode(2);
            var three = graph.CreateNode(3);
            var four = graph.CreateNode(4);
            var five = graph.CreateNode(5);
            var six = graph.CreateNode(6);
            var seven = graph.CreateNode(7);
            var eight = graph.CreateNode(8);

            zero.AddEdge(one, 4).AddEdge(seven, 8);
            one.AddEdge(zero, 4).AddEdge(seven, 11).AddEdge(two, 8);
            two.AddEdge(one, 8).AddEdge(three, 7).AddEdge(five, 4).AddEdge(eight, 2);
            three.AddEdge(two, 7).AddEdge(four, 9).AddEdge(five, 14);
            four.AddEdge(three, 9).AddEdge(five, 10);
            five.AddEdge(two, 4).AddEdge(three, 14).AddEdge(four, 10).AddEdge(six, 2);
            six.AddEdge(five, 2).AddEdge(seven, 1).AddEdge(eight, 6);
            seven.AddEdge(zero, 8).AddEdge(six, 1).AddEdge(eight, 7).AddEdge(one, 11);
            eight.AddEdge(two, 2).AddEdge(six, 6).AddEdge(seven, 7);

            var distance = GetShortestPath(graph, 4);
            Assert.Equal(21, distance);
        }

        private int GetShortestPath(Graph graph, int nodeId)
        {
            var distances = new int[graph.AllNodes.Count];
            for (int i = 1; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            for (int i = 0; i < graph.AllNodes.Count - 1; i++)
            {
                var node = graph.AllNodes[i];
                for (int j = 0; j < node.Edges.Count; j++)
                {
                    var edge = node.Edges[j];
                    if (distances[edge.Parent.Index] != int.MaxValue && distances[edge.Child.Index] > distances[edge.Parent.Index] + edge.Weight)
                        distances[edge.Child.Index] = distances[edge.Parent.Index] + edge.Weight;
                }
            }

            return distances[nodeId];
        }
    }
}