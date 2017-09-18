using System;
using System.Linq;

namespace Q1451
{
    class Program
    {
        static void Main(string[] args)
        {
            #region n,m,matrix 입력받는 코드
            var nm = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            int n = nm[0], m = nm[1];
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                var nums = Console.ReadLine().ToCharArray().Select(item => item - '0').ToArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }
            #endregion

            long result = calculate(matrix, 3, 0, 0, n, m);
            Console.WriteLine(result);
        }

        private static long calculate(int[,] matrix, int sliceCount, int sX, int sY, int eX, int eY)
        {
            if (sliceCount == 1)
            {
                return sumOfRect(matrix, sX, sY, eX, eY);
            }

            long max = 0;
            // 4가지 케이스로 1/2로 슬라이스
            for (var i = sX + 1; i < eX; i++)
            {
                // [v][ ]
                max = Math.Max(max, sumOfRect(matrix, sX, sY, i, eY) * calculate(matrix, sliceCount - 1, i, sY, eX, eY));
                // [ ][v]
                max = Math.Max(max, sumOfRect(matrix, i, sY, eX, eY) * calculate(matrix, sliceCount - 1, sX, sY, i, eY));
            }
            for (var i = sY + 1; i < eY; i++)
            {
                // [v]
                // [ ]
                max = Math.Max(max, sumOfRect(matrix, sX, sY, eX, i) * calculate(matrix, sliceCount - 1, sX, i, eX, eY));
                // [ ]
                // [v]
                max = Math.Max(max, sumOfRect(matrix, sX, i, eX, eY) * calculate(matrix, sliceCount - 1, sX, sY, eX, i));
            }
            return max;
        }

        private static long sumOfRect(int[,] matrix, int sX, int sY, int eX, int eY)
        {
            long sum = 0;
            for (var i = sX; i < eX; i++) for (var j = sY; j < eY; j++) sum += matrix[i, j];
            return sum;
        }
    }
}