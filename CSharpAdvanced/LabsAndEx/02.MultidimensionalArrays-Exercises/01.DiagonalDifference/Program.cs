namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(size, size);

            int leftDiagonalSum = GetLeftDiagonal(matrix);
            int rightDiagonalSum = GetRightDiagonal(matrix);

            int sum = Math.Abs(leftDiagonalSum - rightDiagonalSum);
            Console.WriteLine(sum);
        }

        private static int[,] ReadMatrix(int rows, int cols, string separator = " ")
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
        
        private static int GetLeftDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        private static int GetRightDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, col--)
            {
                sum += matrix[row, col];
            }

            return sum;
        }
    }
}
