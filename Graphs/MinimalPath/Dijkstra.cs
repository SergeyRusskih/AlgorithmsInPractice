using System.Collections.Generic;
using DataStructures.SimpleGraph;
using Xunit;

namespace Graphs.MinimalPath
{
    public class Dijkstra
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
            var visited = new bool[graph.AllNodes.Count];
            var distance = new int[graph.AllNodes.Count];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            var first = graph.AllNodes[0];
            visited[0] = true;
            distance[0] = 0;

            var stack = new Queue<Vertex>();

            foreach (var edge in first.Edges)
            {
                distance[edge.Child.Index] = edge.Weight;
                stack.Enqueue(edge.Child);
            }

            while (stack.Count > 0)
            {
                var vertex = stack.Dequeue();

                for (int i = 0; i < vertex.Edges.Count; i++)
                {
                    var child = vertex.Edges[i].Child;
                    var wight = vertex.Edges[i].Weight;

                    if (visited[child.Index])
                        continue;


                    if (distance[child.Index] == int.MaxValue || distance[child.Index] > distance[vertex.Index] + wight)
                    {
                        distance[child.Index] = distance[vertex.Index] + wight;
                        stack.Enqueue(child);
                    }

                }

                visited[vertex.Index] = true;
            }


            return distance[nodeId];
        }
    }
}