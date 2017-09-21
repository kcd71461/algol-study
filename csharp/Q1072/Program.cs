using System;
using System.Linq;

namespace Q1072
{ 
    // https://www.acmicpc.net/problem/1072
    class Program
    {
        static void Main(string[] args)
        {
            long x, y, z;
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                long[] xy = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => long.Parse(item)).ToArray();
                x = xy[0];
                y = xy[1];
                z = GetRate(x, y);
                if (z >= 99)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(CalculateWithBinarySearch(x, y, 1, x, z));

                    /* n=1 부터 증가시키며 탐색
                    int n = 1;
                    while (true)
                    {
                        if (GetRate(x + n, y + n) > z)
                        {
                            break;
                        }
                        n++;
                    }
                    Console.WriteLine(n);
                    */
                }
            }
        }

        static long CalculateWithBinarySearch(long x, long y, long start, long end, long minRate)
        {
            if (start == end)
            {
                return start;
            }
            long searchNum = (start + end) / 2;
            if (GetRate(x + searchNum, y + searchNum) > minRate)
            {
                return CalculateWithBinarySearch(x, y, start, searchNum, minRate);
            }
            else
            {
                return CalculateWithBinarySearch(x, y, searchNum + 1, end, minRate);
            }
        }

        static long GetRate(long x, long y)
        {
            return (y * 100L / x);
        }
    }
}