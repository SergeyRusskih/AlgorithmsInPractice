using System.Collections.Generic;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class RemoveDuplicates
    {
        [Fact]
        public void Should_Remove_Duplicates()
        {
            var digits = new[] { 2, 2, 2, 8, 8, 8, 10 };

            var result = Calculate(digits);
            Assert.Equal(new[] { 2, 8, 10 }, result);
        }


        private static int[] Calculate(int[] digits)
        {
            var list = new List<int>();

            var prev = digits[0];
            list.Add(prev);

            for (int i = 1; i < digits.Length; i++)
            {
                var current = digits[i];
                if (current == prev)
                    continue;

                prev = current;
                list.Add(current);

            }

            return list.ToArray();
        }
    }
}