using System;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class Anagrams
    {
        [Fact]
        public void Should_Detect_Anagram()
        {
            var val1 = "qiu";
            var val2 = "iuq";
            var result = Calculate(val1, val2);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Not_Detect_Anagram()
        {
            var val1 = "zprl";
            var val2 = "zprс";
            var result = Calculate(val1, val2);
            Assert.Equal(0, result);
        }

        private int Calculate(string val1, string val2)
        {
            if (val1.Length != val2.Length)
                return 0;

            var arr1 = val1.ToCharArray();
            var arr2 = val2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            var val3 = new string(arr1);
            var val4 = new string(arr2);

            return val4 == val3
                ? 1
                : 0;
        }
    }
}