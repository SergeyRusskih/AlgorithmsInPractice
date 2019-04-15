using System;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class OnesSequence
    {
        [Fact]
        public void Should_Find_Longest_Sequence()
        {
            var digits = new[] { 1, 0, 1, 1, 0, 1, 1 };

            var result = Calculate(digits);
            Assert.Equal(2, result);
        }

        private int Calculate(int[] digits)
        {
            var result = 0;

            var tmp = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                var current = digits[i];
                if (current != 1)
                {
                    tmp = 0;
                    continue;
                }

                result = Math.Max(++tmp, result);
            }

            return result;
        }
    }
}