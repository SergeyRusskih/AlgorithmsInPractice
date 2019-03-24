using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class ChangeCoin
    {
        private static int[] Coins = { 1, 5, 20 };

        private int Change(int value)
        {
            var canReach = new bool[value + 1, value / Coins[0]];

            for (int j = 0; j < Coins.Length; j++)
            {
                var left = value - Coins[j];
                if (left == 0)
                    return 1;

                if (left < 0)
                    continue;

                canReach[left, 0] = true;
            }

            var length = canReach.GetLength(0);
            var length1 = canReach.GetLength(1);

            for (int j = 1; j < length1; j++) // y
            {
                for (int i = 0; i < length; i++) // x
                {
                    var prev = canReach[i, j - 1]; // x, y - 1
                    if (!prev)
                        continue;

                    for (int k = 0; k < Coins.Length; k++) // options for next on x on current y axes
                    {
                        var left = i - Coins[k]; // left = x
                        if (left < 0)
                            continue;

                        canReach[left, j] = true;
                    }
                }
            }

            for (int i = 0; i < length1; i++)
            {
                if (canReach[0, i])
                    return i + 1;
            }

            return int.MaxValue;
        }

        [Fact]
        public void Should_Change_Coins()
        {
            var result1 = Change(7);
            Assert.Equal(3, result1);

            var result2 = Change(10);
            Assert.Equal(2, result2);

            var result3 = Change(20);
            Assert.Equal(1, result3);
        }
    }
}
