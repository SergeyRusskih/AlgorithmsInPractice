using System;
using System.IO;
using Xunit;

namespace Interviews.Yandex.Preparation
{
    public class ArrayMerge
    {
        [Fact]
        public void Should_Merge_Arrays()
        {
            const string WhiteSpace = " ";
            var file = new StreamReader("input.txt");
            var arrayCount = GetNext(file);

            var arr = new int[arrayCount * arrayCount * 10];
            int i = 0;
            for (; i < arr.Length;)
            {
                var length = GetNext(file);
                if (length == -1)
                    break;

                for (int j = 0; j < length; ++j)
                {
                    arr[i] = GetNext(file);
                    ++i;
                }
            }

            Array.Sort(arr, 0, i);

            var file1 = new StreamWriter("output.txt");
            for (int j = 0; j < i; j++)
            {
                file1.Write(arr[j]);
                file1.Write(WhiteSpace);

                if (j % 10 == 0)
                    file1.Flush();
            }

            file1.Flush();

            //var indexes = new int[arrayCount];

            //var minValue = int.MaxValue;
            //var minIndex = int.MaxValue;

            //var file1 = new StreamWriter("output.txt");
            //for (int i = 0; i < totalLength; ++i)
            //{
            //    var first = true;
            //    for (int j = 0; j < indexes.Length; ++j)
            //    {
            //        if (arr[j].Length <= indexes[j])
            //            continue;

            //        var val = arr[j][indexes[j]];

            //        if (first && val == minValue)
            //        {
            //            minValue = val;
            //            minIndex = j;
            //            break;
            //        }

            //        if (first || val < minValue)
            //        {
            //            minValue = val;
            //            minIndex = j;
            //            first = false;
            //        }
            //    }

            //    ++indexes[minIndex];
            //    file1.Write(minValue);
            //    file1.Write(WhiteSpace);
            //}

            //file1.Flush();
        }

        private static int GetNext(StreamReader file)
        {
            var s = string.Empty;

            int i = 0;

            while ((i = file.Read()) != -1)
            {
                var c = Convert.ToChar(i);
                if (char.IsDigit(c) || char.IsLetter(c))
                {
                    s = s + c;
                }
                else
                {
                    if (s.Trim() != string.Empty)
                        return int.Parse(s);

                    s = string.Empty;
                }
            }

            if (s.Trim() != string.Empty)
                return int.Parse(s);

            return -1;
        }
    }
}