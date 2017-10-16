using System;

namespace Q1543
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string search = Console.ReadLine();
            int count = 0;
            int index;
            while ((index = input.IndexOf(search)) >= 0)
            {
                count++;
                input = input.Substring(index + search.Length);
            }
            Console.WriteLine(count);
        }
    }
}