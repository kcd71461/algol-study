using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2156
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var juices = new int[n];
            for(int i = 0; i < n; i++)
            {
                juices[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(Process(juices));
        }

        static int Process(int[] juices)
        {
            int n = juices.Length;
            int[] matrix = new int[n];
            for(int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    matrix[n - i] = juices[n - i];
                }
                else if (i == 2)
                {
                    matrix[n - i] = juices[n - 1] + juices[n - 2];
                }
                else if (i == 3)
                {
                    matrix[n - i] = Max(
                        matrix[n - i + 1], // X
                        matrix[n - i + 2] + juices[n - i], // O X
                        juices[n - i] + juices[n - i + 1]
                        );
                }
                else
                {
                    matrix[n - i] = Max(
                        matrix[n - i + 1], // X
                        matrix[n - i + 2] + juices[n - i], // O X
                        matrix[n - i + 3] + juices[n - i] + juices[n - i + 1] // O O X
                        );
                }
            }
            return matrix[0];
        }

        private static int Max(int v1, int v2, int v3)
        {
            int temp = v1 > v2 ? v1 : v2;
            return temp > v3 ? temp : v3;
        }
    }
}
