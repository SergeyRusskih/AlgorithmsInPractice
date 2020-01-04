using Xunit;

namespace Miscellaneous.TravelingSalesmanBruteForce
{
    public class TravelingSalesmanTests
    {
        [Fact]
        public void Should_Return_Correct_Result_For_Simple_Input()
        {
            var input = new[] { -20, -1 };
            var runner = new TravelingSalesman();
            var result = runner.Run(input);

            Assert.Equal(19, result);
        }

        [Fact]
        public void Should_Return_Correct_Result_For_Complex_Input()
        {
            var input = new[] { -20, -1, 0, 1, 15 };
            var runner = new TravelingSalesman();
            var result = runner.Run(input);

            Assert.Equal(35, result);
        }
    }
}