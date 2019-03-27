using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DynamicProgramming.TopDown
{
    public class CuttingSticks
    {
        private int FindMinimalCutCost(int stick)
        {
            if (stick == 0)
                return 0;
            return -1;
        }

        [Fact]
        public void Should_Find_Minimal_Cost()
        {
            var stick = 100;

        }
    }
}
