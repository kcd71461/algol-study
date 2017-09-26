using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10844
{
    class Program
    {
        const int MAX_NUM = 1000000000;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Process(n));
        }

        private static int Process(int n)
        {
            int[,] matrix = new int[10, n]; // [startNumber,length]
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (i == 0)
                    {
                        matrix[j, i] = 1;
                    }
                    else
                    {
                        if (j == 0)
                        {
                            matrix[j, i] = matrix[j + 1, i - 1];
                        }
                        else if (j == 9)
                        {
                            matrix[j, i] = matrix[j - 1, i - 1];
                        }
                        else
                        {
                            matrix[j, i] = (int)(((long)matrix[j - 1, i - 1] + (long)matrix[j + 1, i - 1]) % MAX_NUM);
                        }
                    }
                }
            }
            long sum = 0;
            for (var i = 1; i < 10; i++)
            {
                sum = (sum + matrix[i, n - 1]) % MAX_NUM;
            }
            return (int)sum;
        }
    }
}
