using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11057
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            Console.WriteLine(Process(n));
        }

        static int Process(long n)
        {
            int[,] matrix = new int[10, n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        int sum = 0;
                        for (int k = i; k < 10; k++)
                        {
                            sum += (matrix[k, j - 1]);
                            sum %= 10007;
                        }
                        matrix[i, j] = sum;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < 10; i++)
            {
                result += matrix[i, n - 1];
                result %= 10007;
            }
            return result;
        }
    }
}