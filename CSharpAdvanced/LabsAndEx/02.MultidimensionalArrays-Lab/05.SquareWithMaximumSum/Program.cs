namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(", ");

            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            int[,] matrix = ReadNumberMatrix(rows, cols, ", ");

            int biggestSum = 0;
            int biggestRow = 0;
            int biggestCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int squareSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (squareSum > biggestSum)
                    {
                        biggestSum = squareSum;

                        biggestRow = row;
                        biggestCol = col;
                    }
                }
            }

            Console.WriteLine(matrix[biggestRow, biggestCol] + " " + matrix[biggestRow, biggestCol + 1]);
            Console.WriteLine(matrix[biggestRow + 1, biggestCol] + " "+ matrix[biggestRow + 1, biggestCol + 1]);
            Console.WriteLine(biggestSum);
        }
        private static int[,] ReadNumberMatrix(int rows, int cols, string separator)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(separator).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            return matrix;
        }
    }
}
