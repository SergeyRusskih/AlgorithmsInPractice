using System;
using Xunit;

namespace StringProcessing.Search.Kmp
{
    public class KmpTests
    {
        private readonly Kmp _kmp;

        public KmpTests()
        {
            _kmp = new Kmp();
        }

        [Fact]
        public void RunSearch_Returns_Empty_Array_If_No_Match_Found()
        {
            var arr = new[] {4, 8, 6, 12};

            var result = _kmp.minimumTime(4, arr);

            //var text = "aaaaab";
            //var pattern = "aab";
            //var result = _kmp.Run(text, pattern);
            //Assert.Equal(1, result);
        }
    }
}
