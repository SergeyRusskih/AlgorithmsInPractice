namespace Miscellaneous.Matrixes
{
    /// <summary>
    /// Brute force method to multipy two matrixes.
    /// 
    /// We should have matrixes NxM and MxA.
    /// Result matrix will have size NxA.
    /// 
    /// Complexity - O(n3)
    /// </summary>
    public class BruteForce
    {
        public int[][] Run(int[][] firstMatrix, int[][] secondMatrix)
        {
            var result = new int[firstMatrix.Length][];

            for (var i = 0; i < firstMatrix.Length; i++)
            {
                result[i] = new int[secondMatrix[0].Length];
                for (var j = 0; j < secondMatrix[0].Length; j++)
                {
                    for (var k = 0; k < firstMatrix[0].Length; k++)
                    {
                        result[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
                    }
                }
            }
            
            return result;
        }
    }
}
