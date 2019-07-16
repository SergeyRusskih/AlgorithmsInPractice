using System.Collections.Generic;

namespace DataStructures.SimpleGraph
{
    public class Vertex
    {
        public int Index { get; }
        public List<Edge> Edges { get; } = new List<Edge>();

        public Vertex(int index)
        {
            Index = index;
        }

        public Vertex AddEdge(Vertex child, int weight)
        {
            Edges.Add(new Edge
            {
                Parent = this,
                Child = child,
                Weight = weight
            });

            return this;
        }
    }
}