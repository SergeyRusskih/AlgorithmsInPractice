using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Miscellaneous
{
    public class MovieScheduling
    {
        private class Movie
        {
            public Movie(int[] pair)
            {
                Start = pair[0];
                End = pair[1];
            }

            public int Start { get; }
            public int End { get; }
        }

        private int Run(int[][] schedule)
        {
            var list = schedule.Select(s => new Movie(s)).ToList();
            var count = 0;

            var i = 0;
            while (list.Count != 0)
            {
                var isPointFound = false;
                var candidates = new List<Movie>();

                while (!isPointFound)
                {
                    foreach (var movie in list)
                    {
                        if (i == movie.Start)
                        {
                            candidates.Add(movie);
                        }

                        if (i != movie.End) continue;
                        isPointFound = true;
                    }

                    i++;
                }

                var winner = candidates[0];
                if (candidates.Count > 1)
                {
                    for (int j = 1; j < candidates.Count; j++)
                    {
                        if (candidates[j].End < winner.End)
                        {
                            winner = candidates[j];
                        }
                    }
                }

                foreach (var movie in list.ToList())
                {
                    if (movie.Start <= winner.End)
                        list.Remove(movie);
                }

                count++;
            }

            return count;
        }

        [Fact]
        public void Should_Count_Complex_Timeline()
        {
            var schedule = new[]
            {
                new[] {0, 6},   // Tarjan of the Jungle
                new[] {1, 5},   // The President’s Algorist
                new[] {2, 3},   // "Discrete" Mathematics - win

                new[] {4, 8},   // Halting State - win
                new[] {6, 10},  // Steiner’s Tree

                new[] {9, 15},  // The Four Volume Problem
                new[] {11, 14}, // Programming Challenges - win
                new[] {13, 17}, // Process Terminated

                new[] {15, 18}, // Calculated Bets - win
            };

            var result = Run(schedule);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Should_Count_Single_Long_Movie()
        {
            var schedule = new[]
            {
                new[] {0, 20},
                new[] {1, 2},
                new[] {4, 5},
                new[] {7, 8},
                new[] {10, 11},
                new[] {13, 14},
                new[] {15, 16},
                new[] {18, 19}
            };

            var result = Run(schedule);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Should_Count_Not_Shortest_But_Best()
        {
            var schedule = new[]
            {
                new[] {0, 10},
                new[] {13, 20},
                new[] {10, 15}
            };

            var result = Run(schedule);
            Assert.Equal(2, result);
        }
    }
}
