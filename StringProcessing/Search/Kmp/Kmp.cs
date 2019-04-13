namespace StringProcessing.Search.Kmp
{
    public class Kmp
    {
        public int Run(string text, string pattern)
        {
            var lps = BuildLps(pattern + "@" + text);

            var count = 0;
            foreach (var value in lps)
            {
                if (value == pattern.Length)
                    count++;
            }

            return count;
        }

        private int[] BuildLps(string input)
        {
            var result = new int[input.Length];
            for (var i = 1; i < input.Length; i++)
            {
                var j = result[i - 1];
                while (j > 0 && input[i] != input[j])
                {
                    j = result[j - 1];
                }

                if (input[i] == input[j])
                    j++;

                result[i] = j;
            }

            return result;
        }
    }
}
