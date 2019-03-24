using Xunit;

namespace DynamicProgramming.BottomUp
{
    public class WeddingShopping
    {
        public int GetBudget(int money, int[][] items)
        {
            var canReach = new bool[money, items.GetLength(0)];
            return Shop(money, canReach, items);
        }

        private int Shop(int money, bool[,] canReach, int[][] items)
        {
            for (int i = 0; i < items[0].Length; i++)
            {
                var left = money - items[0][i];
                if (left < 0)
                    continue;

                canReach[left, 0] = true;
            }


            var garmentLength = items.GetLength(0);
            for (int garment = 1; garment < garmentLength; garment++)
            {
                for (int moneyItem = 0; moneyItem < money; moneyItem++)
                {
                    if (!canReach[moneyItem, garment - 1])
                        continue;

                    for (int k = 0; k < items[garment].Length; k++)
                    {
                        var left = moneyItem - items[garment][k];
                        if (left < 0)
                            continue;

                        canReach[left, garment] = true;
                    }
                }
            }

            for (int i = 0; i < money; i++)
            {
                if (!canReach[i, garmentLength - 1])
                    continue;

                return money - i;
            }

            return -1;
        }

        [Fact]
        public void Example_Input()
        {
            var money = 20;
            var items = new[]
            {
                new [] { 6, 4, 8 },
                new [] { 5, 10},
                new [] { 1, 5, 3, 5}
            };

            var result = GetBudget(money, items);

            Assert.Equal(19, result);
        }

        [Fact]
        public void Minimal_Input()
        {
            var money = 9;
            var items = new[]
            {
                new [] { 6, 4, 8 },
                new [] { 5, 10},
                new [] { 1, 5, 3, 5}
            };

            var result = GetBudget(money, items);

            Assert.Equal(-1, result);
        }
    }
}
