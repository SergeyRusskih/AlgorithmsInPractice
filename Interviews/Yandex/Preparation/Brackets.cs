using System.Collections.Generic;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class Brackets
    {
        [Fact]
        public void Should_Create_Brackets_Properly_In_Simple_Case()
        {
            var i = 2;
            var result = new List<string>();
            Calculate(result, new char[i * 2]);
            Assert.Contains("(())", result);
            Assert.Contains("()()", result);
        }

        [Fact]
        public void Should_Create_Brackets_Properly_In_Complex_Case()
        {
            var i = 3;
            var result = new List<string>();
            Calculate(result, new char[i * 2]);
            Assert.Contains("((()))", result);
            Assert.Contains("(()())", result);
            Assert.Contains("(())()", result);
            Assert.Contains("()(())", result);
            Assert.Contains("()()()", result);
        }

        private void Calculate(List<string> result, char[] c, int open = 0, int closed = 0)
        {
            var total = open + closed;
            if (c.Length > total)
            {
                if (open < c.Length / 2)
                {
                    c[total] = '(';
                    Calculate(result, c, open + 1, closed);
                }

                if (open > closed)
                {
                    c[total] = ')';
                    Calculate(result, c, open, closed + 1);
                }
            }
            else
            {
                result.Add(new string(c));
            }
        }
    }
}