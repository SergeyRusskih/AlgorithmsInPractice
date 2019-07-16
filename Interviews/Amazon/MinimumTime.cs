using System;

namespace Interviews.Amazon
{
    public class MinimumTime
    {
        public int minimumTime(int numOfSubFiles, int[] files)
        {
            return merge(0, numOfSubFiles, files);
        }

        private int merge(int index, int numOfSubFiles, int[] files)
        {
            if (index + 1 >= numOfSubFiles || index >= files.Length)
                return 0;

            Array.Sort(files);

            var current = files[index];
            var next = files[index + 1];

            var time = current + next;

            files[index + 1] = time;
            files[index] = 0;

            var result = merge(++index, numOfSubFiles, files);

            return time + result;
        }
    }
}