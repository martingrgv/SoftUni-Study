namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(size, size);
            char symbol = char.Parse(Console.ReadLine());

            int[] coords = GetSymbolCoords(matrix, symbol);

            if (coords[0] == -1 && coords[1] == -1)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
                return;
            }

            Console.WriteLine($"({coords[0]}, {coords[1]})");
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string str = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = str[col];
                }
            }

            return matrix;
        }

        private static int[] GetSymbolCoords(char[,] matrix, char symbol)
        {
            int[] coords = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char ch = matrix[row, col];

                    if (ch == symbol)
                    {
                        coords[0] = row;
                        coords[1] = col;

                        return coords;
                    }
                }
            }

            return new int[]{ -1, -1 };
        }
    }
}
