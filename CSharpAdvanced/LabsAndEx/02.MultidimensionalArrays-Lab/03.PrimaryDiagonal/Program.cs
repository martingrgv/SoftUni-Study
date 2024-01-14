namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = ReadNumberMatrix(size, size, " ");

            int sum = GetPrimaryDiagonalSum(matrix);

            Console.WriteLine(sum);
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

        private static int GetPrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0, col = 0; row < matrix.GetLength(0); row++, col++)
            {
                sum += matrix[row, col];
            }

            return sum;
        }
    }
}
