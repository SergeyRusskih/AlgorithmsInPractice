using System.Collections.Generic;

public class Graph
{
    public List<Vertex> AllNodes { get; } = new List<Vertex>();

    public Vertex CreateNode(int index)
    {
        var n = new Vertex(index);
        AllNodes.Add(n);
        return n;
    }
}