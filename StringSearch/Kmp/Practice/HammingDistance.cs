using System.Collections.Generic;
using Xunit;

namespace StringSearch.Kmp.Practice
{
    public class HammingDistance
    {
        public string Run(List<string> list)
        {
            var minDistance = int.MaxValue;
            var beautiful = string.Empty;
            for (var i = 0; i < list.Count; i++)
            {
                var distance = 0;
                for (var j = 0; j < list.Count; j++)
                {
                    if (i == j) continue;
                    distance = Calculate(list[i], list[j]);
                }

                if (distance < minDistance)
                    minDistance = distance;
                else if (distance == minDistance)
                {
                    for (var k = 0; k < beautiful.Length; k++)
                    {
                        if (list[i][k] < beautiful[k])
                        {
                            beautiful = list[i];
                            break;
                        }

                        if (list[i][k] > beautiful[k])
                            break;
                    }
                }
            }

            return beautiful;
        }

        private int Calculate(string s, string s1)
        {
            var count = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != s1[i]) count++;
            }

            return count;
        }

        [Fact]
        public void HammingDistance_Sample_Test()
        {
            var result = Run(new List<string> {"a", "b"});
            Assert.Equal("a", result);
        }
    }
}