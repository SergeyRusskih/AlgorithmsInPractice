using System.Linq;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class StonesAndJewelries
    {
        [Fact]
        public void Should_Count_Properly()
        {
            var jew = "ab";
            var str = "aabbccd";

            var result = Calculate(jew, str);
            Assert.Equal(4, result);
        }

        private int Calculate(string jew, string str)
        {
            var jews = jew.ToCharArray().Distinct();

            int count = 0;
            foreach (var s in str.ToCharArray())
            {
                if (jews.Contains(s))
                    count++;
            }

            return count;
        }
    }
}