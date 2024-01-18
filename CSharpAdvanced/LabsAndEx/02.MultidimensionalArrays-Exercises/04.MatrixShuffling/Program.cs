namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = ReadMatrix(rows, cols);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "swap" && tokens.Length == 5)
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row1 >= 0 && row1 < matrix.GetLength(0) && // if in range
                        col1 >= 0 && col1 < matrix.GetLength(1) && 
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        string temp = matrix[row1, col1];

                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        PrintMatrix(matrix);
                        continue;
                    }
                }

                Console.WriteLine("Invalid input!");
            }
        }

        private static string[,] ReadMatrix(int rows, int cols, string separator = " ")
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] arr = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
