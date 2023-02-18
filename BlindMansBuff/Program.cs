using System;
using System.Linq;

namespace BlindMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrIndex = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = arrIndex[0];
            int m = arrIndex[1];
            int row = 0;
            int col = 0;
            string[,] matrix = new string[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(" ");
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = arr[j];
                    if (matrix[i, j] == "B")
                    {
                        matrix[i, j] = "-";
                        row = i; col = j;
                    }
                }
            }
            int touchedOpponents = 0;
            int movesMade = 0;
            string input = Console.ReadLine();
            while (input != "Finish")
            {
                switch (input)
                {
                    case "up":
                        if (ValidIndex(matrix, row - 1, col))
                        {
                            if (matrix[row - 1, col] == "P")
                            {
                                row--;
                                movesMade++;
                                touchedOpponents++;
                                matrix[row,col] = "-";
                            }
                            else if (matrix[row - 1, col] == "-")
                            {
                                row--;
                                movesMade++;
                            }
                        }
                        break;
                    case "down":
                        if (ValidIndex(matrix, row + 1, col))
                        {
                            if (matrix[row + 1, col] == "P")
                            {
                                row++;
                                movesMade++;
                                touchedOpponents++;
                                matrix[row, col] = "-";
                            }
                            else if (matrix[row + 1, col] == "-")
                            {
                                row++;
                                movesMade++;
                            }
                        }
                        break;
                    case "left":
                        if (ValidIndex(matrix, row, col - 1))
                        {
                            if (matrix[row, col - 1] == "P")
                            {
                                col--;
                                movesMade++;
                                touchedOpponents++;
                                matrix[row, col] = "-";
                            }
                            else if (matrix[row, col - 1] == "-")
                            {
                                col--;
                                movesMade++;
                            }
                        }
                        break;
                    case "right":
                        if (ValidIndex(matrix,row, col + 1))
                        {
                            if (matrix[row, col + 1] == "P")
                            {
                                col++;
                                movesMade++;
                                touchedOpponents++;
                                matrix[row, col] = "-";
                            }
                            else if (matrix[row, col + 1] == "-")
                            {
                                col++;
                                movesMade++;
                            }
                        }
                        break;
                }
                if (touchedOpponents == 3)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");

        }
        public static bool ValidIndex(string[,] matrixDuplicate, int row, int col)
        {
            if (row >= 0 && row < matrixDuplicate.GetLength(0) && col >= 0 && col < matrixDuplicate.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
