namespace _01.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(", ");

            int rowSize = int.Parse(size[0]);
            int colSize = int.Parse(size[1]);

            int[,] matrix = new int[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++) // Add input to matrix
            {
                int[] rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++) // Get sum
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
