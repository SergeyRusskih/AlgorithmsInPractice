using System;
using System.Collections.Generic;

namespace StringProcessing.Search.Kmp
{
    public class Kmp
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

        public int minimumTime(int numOfSubFiles, int[] files)
        {
            return merge(0, numOfSubFiles, files);
        }

        private int merge(int index, int numOfSubFiles, int[] files)
        {
            if (index + 1 >= numOfSubFiles || index >= files.Length)
                return 0;

            Array.Sort(files);

            var current = files[index];
            var next = files[index + 1];

            var time = current + next;

            files[index + 1] = time;
            files[index] = 0;

            var result = merge(++index, numOfSubFiles, files);

            return time + result;
        }

        public int Run(string text, string pattern)
        {


            var lps = BuildLps(pattern + "@" + text);

            var count = 0;
            foreach (var value in lps)
            {
                if (value == pattern.Length)
                    count++;
            }

            return count;
        }

        private int[] BuildLps(string input)
        {
            var result = new int[input.Length];
            for (var i = 1; i < input.Length; i++)
            {
                var j = result[i - 1];
                while (j > 0 && input[i] != input[j])
                {
                    j = result[j - 1];
                }

                if (input[i] == input[j])
                    j++;

                result[i] = j;
            }

            return result;
        }
    }
}
