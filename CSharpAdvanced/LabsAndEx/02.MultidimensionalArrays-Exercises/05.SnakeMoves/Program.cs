namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            char[,] snake = new char[rows, cols];

            string word = Console.ReadLine();
            int wordCounter = 0;

            // Add
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    snake[row, col] = word[wordCounter];

                    wordCounter++;

                    if (wordCounter >= word.Length)
                        wordCounter = 0;
                }

                if (row + 1 < rows)
                {
                    row++;
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        snake[row, col] = word[wordCounter];

                        wordCounter++;

                        if (wordCounter >= word.Length)
                            wordCounter = 0;
                    }
                }
            }

            // Print
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(snake[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
