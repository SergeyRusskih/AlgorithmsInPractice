using System.Collections.Generic;

namespace Greedy
{
    public class Kruskals
    {
        public void Should_Find_Minimal_Spanning_Tree()
        {
            var tree = new List<List<int>>
            {
                new List<int> { 1, 3 },          // A
                new List<int> { 0, 2, 3 },       // B
                new List<int> { 2, 4 },          // C
                new List<int> { 0, 1, 4, 6 },     // D
                new List<int> { 1, 2, 3, 5, 6 }, // E
                new List<int> { 3, 4, 6 },       // F
                new List<int> { 4, 5 }           // G
            };

            var weights = new List<List<int>>
            {
                new List<int> { 7, 5 },           // A
                new List<int> { 7, 8, 9 },        // B
                new List<int> { 8, 5 },           // C
                new List<int> { 5, 9, 15, 6 },    // D
                new List<int> { 7, 5, 15, 8, 9 }, // E
                new List<int> { 6, 8, 11 },       // F
                new List<int> { 9, 11 }           // G
            };
        }
    }
}