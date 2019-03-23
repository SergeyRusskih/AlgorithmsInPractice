using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class WeddingShopping
    {
        public int GetBudget(int money, int[][] items)
        {
            return -1;
        }

        public void Should_Calculate_Correctly()
        {
            var money = 200;
            var items = new[]
            {
                new [] { 6, 4, 8 },
                new [] { 5, 10},
                new [] { 1, 5, 3, 5}
            };

            var result = GetBudget(money, items);

        }
    }
}
