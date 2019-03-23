using System;
using Xunit;

namespace DynamicProgramming.TopDown
{
    public class WeddingShopping
    {
        public int GetBudget(int money, int[][] items)
        {
            var memo = new int[money + 1, items.Length];
            return Shop(money, money, memo, items, 0);
        }

        private int Shop(int money, int moneyLeft, int[,] memo, int[][] items, int id)
        {
            if (moneyLeft < 0)
                return -1;

            var categoriesLength = memo.GetLength(1);
            if (id == categoriesLength)
                return money - moneyLeft;

            if (memo[moneyLeft, id] != 0)
                return memo[moneyLeft, id];

            var maxValue = -1;
            for (int model = 0; model < items[id].Length; model++)
            {
                var nextMoney = moneyLeft - items[id][model];
                maxValue = Math.Max(maxValue, Shop(money, nextMoney, memo, items, id + 1));
            }

            memo[moneyLeft, id] = maxValue;

            return maxValue;
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
