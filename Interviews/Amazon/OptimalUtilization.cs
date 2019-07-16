using System.Collections.Generic;

namespace Interviews.Amazon
{
    public class OptimalUtilization
    {
        public List<List<int>> optimalUtilization(int deviceCapacity,
            List<List<int>> foregroundAppList,
            List<List<int>> backgroundAppList)
        {
            // WRITE YOUR CODE HERE
            var candidates = new List<List<int>>();

            var maxCapacity = int.MinValue;
            foreach (var foreground in foregroundAppList)
            {
                foreach (var background in backgroundAppList)
                {
                    var capacity = foreground[1] + background[1];
                    if (capacity > deviceCapacity || capacity < maxCapacity)
                        continue;

                    if (candidates.Count == 0)
                    {
                        maxCapacity = capacity;
                        candidates.Add(new List<int>
                        {
                            foreground[0],
                            background[0]
                        });

                        continue;
                    }

                    if (capacity == maxCapacity)
                    {
                        candidates.Add(new List<int>
                        {
                            foreground[0],
                            background[0]
                        });

                        continue;
                    }

                    maxCapacity = capacity;
                    candidates = new List<List<int>>
                    {
                        new List<int>
                        {
                            foreground[0],
                            background[0]
                        }
                    };
                }
            }

            return candidates;
        }
    }
}