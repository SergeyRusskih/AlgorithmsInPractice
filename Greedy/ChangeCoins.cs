using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Greedy
{
    public class ChangeCoins
    {
        private static int[] CoinsAvailable = {
            25, 20, 20, 15, 5, 1, 1
        };

        public static int[] Change(int value)
        {
            var result = new List<int>();
            var current = 0;
            var coins = CoinsAvailable.ToList();
            while (current < value)
            {
                for (int j = 0; j < coins.Count; j++)
                {
                    var next = current + coins[j];
                    if (next > value)
                        continue;

                    current += coins[j];
                    result.Add(coins[j]);
                    coins.RemoveAt(j);
                    break;
                }
            }

            return result.ToArray();
        }

        [Fact]
        public void Should_Change_Coins_Correctly()
        {
            var value = 51;
            var result = Change(value);

            var expected = new[] { 25, 20, 5, 1 };
            Assert.Equal(expected, result);
        }
    }
}
