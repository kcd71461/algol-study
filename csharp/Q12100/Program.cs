using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q12100
{
    class Program
    {
        enum Directions
        {
            UP, DOWN, LEFT, RIGHT
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
                for (var j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
            Console.WriteLine(Calculate(n, matrix, 5));
        }

        static int Calculate(int n, int[,] matrix, int count)
        {
            int max = 0;
            bool leftMovable = CheckMovableMatrix(n, matrix, Directions.LEFT),
                rightMovable = CheckMovableMatrix(n, matrix, Directions.RIGHT),
                upMovable = CheckMovableMatrix(n, matrix, Directions.UP),
                downMovable = CheckMovableMatrix(n, matrix, Directions.DOWN);

            if (count > 0 && (
                (leftMovable) ||
                (rightMovable) ||
                (upMovable) ||
                (downMovable)
                )
                )
            {

                if (leftMovable)
                {
                    max = Math.Max(Calculate(n, MoveMatrix(n, matrix, Directions.LEFT), count - 1), max);
                }
                if (rightMovable)
                {
                    max = Math.Max(Calculate(n, MoveMatrix(n, matrix, Directions.RIGHT), count - 1), max);
                }
                if (upMovable)
                {
                    max = Math.Max(Calculate(n, MoveMatrix(n, matrix, Directions.UP), count - 1), max);
                }
                if (downMovable)
                {
                    max = Math.Max(Calculate(n, MoveMatrix(n, matrix, Directions.DOWN), count - 1), max);
                }
            }
            else
            {
                for (var i = 0; i < n; i++)
                    for (var j = 0; j < n; j++)
                        max = Math.Max(matrix[i, j], max);
            }

            return max;
        }

        static bool CheckMovableMatrix(int n, int[,] matrix, Directions direction)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    int row = -1, col = -1;
                    int previousValue = -1;
                    switch (direction)
                    {
                        // 현재 공간이 안비었고 직전 공간이 비어있으면 movable
                        // 현재 공간이 안비었고 현재 공간 값과 직전 공간의 값과 같으면 movable
                        case Directions.LEFT:
                            row = i;
                            col = j;
                            previousValue = matrix[row, col - 1];
                            break;
                        case Directions.RIGHT:
                            row = i;
                            col = n - 1 - j;
                            previousValue = matrix[row, col + 1];
                            break;
                        case Directions.UP:
                            row = j;
                            col = i;
                            previousValue = matrix[row - 1, col];
                            break;
                        case Directions.DOWN:
                            row = n - 1 - j;
                            col = i;
                            previousValue = matrix[row + 1, col];
                            break;
                    }
                    if (matrix[row, col] != 0)
                    {
                        if (previousValue == 0 || previousValue == matrix[row, col])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static int[,] MoveMatrix(int n, int[,] matrix, Directions direction)
        {
            int[,] newMatrix = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                var values = new List<int>(5);
                for (var j = 0; j < n; j++)
                {
                    switch (direction)
                    {
                        case Directions.LEFT:
                        case Directions.RIGHT:
                            values.Add(matrix[i, j]);
                            break;
                        case Directions.UP:
                        case Directions.DOWN:
                            values.Add(matrix[j, i]);
                            break;
                    }
                }
                IEnumerable<int> valuesEnumarable = values.Where(item => item != 0);
                switch (direction)
                {
                    case Directions.RIGHT:
                    case Directions.DOWN:
                        valuesEnumarable = valuesEnumarable.Reverse();
                        break;
                }
                values = valuesEnumarable.ToList();
                int offset = 0;
                while (true)
                {
                    // 다음 요소가 존재하는가?
                    if (values.Count <= offset + 1)
                    {
                        break;
                    }
                    if (values[offset] == values[offset + 1])
                    {
                        values.RemoveAt(offset);
                        values[offset] *= 2;
                    }
                    offset++;
                }

                for (int j = 0; j < n; j++)
                {
                    int insertValue = values.Count <= j ? 0 : values[j];
                    switch (direction)
                    {
                        case Directions.LEFT:
                            newMatrix[i, j] = insertValue;
                            break;
                        case Directions.RIGHT:
                            newMatrix[i, n - 1 - j] = insertValue;
                            break;
                        case Directions.UP:
                            newMatrix[j, i] = insertValue;
                            break;
                        case Directions.DOWN:
                            newMatrix[n - 1 - j, i] = insertValue;
                            break;
                    }
                }

            }
            return newMatrix;
        }

        static int Max(params int[] values)
        {
            int max = int.MinValue;
            foreach (var value in values)
            {
                max = Math.Max(value, max);
            }
            return max;
        }
    }
}