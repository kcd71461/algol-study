using System;

namespace Q2966
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] answers = Console.ReadLine().ToCharArray();
            String[] names = new String[3];
            names[0] = "Adrian";
            names[1] = "Bruno";
            names[2] = "Goran";

            // 상근이는 A, B, C, A, B, C, A, B, C, A, B, C
            // 창영이는 B, A, B, C, B, A, B, C, B, A, B, C,
            // 현진이는 C, C, A, A, B, B, C, C, A, A, B, B, ...

            int[] scores = new int[3];
            for (int i = 0; i < 3; i++) scores[i] = 0;

            int[] submits = new int[3];
            for (int i = 0; i < n; i++)
            {
                char answer = answers[i];
                int temp = ((i / 2) % 3);
                submits[0] = 'A' + (char)(i % 3);
                submits[1] = (i % 2 == 0) ? 'B' : ((i % 4 == 1) ? 'A' : 'C');
                submits[2] = temp == 0 ? 'C' : (temp == 1 ? 'A' : 'B');

                for (int j = 0; j < 3; j++)
                {
                    if (submits[j] == answer)
                    {
                        scores[j]++;
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < 3; i++)
            {
                if (max < scores[i]) max = scores[i];
            }
            Console.WriteLine(max);
            for (int i = 0; i < 3; i++)
            {
                if (scores[i] == max)
                    Console.WriteLine(names[i]);
            }
        }
    }
}
