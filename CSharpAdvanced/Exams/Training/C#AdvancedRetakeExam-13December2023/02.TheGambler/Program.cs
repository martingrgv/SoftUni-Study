namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = SetBoard();

            int[] gamblerPos = GetGamblerPosition(board);
            string move;
            int score = 100;

            do
            {
                move = Console.ReadLine();
            }
            while (CanMove(board, gamblerPos, move, ref score));
        }

        private static char[,] SetBoard()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        private static int[] GetGamblerPosition(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 'G')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return null;
        }

        private static bool CanMove(char[,] board, int[] gamblerPos, string move, ref int score)
        {
            try
            {
                char steppedChar = ' ';

                if (move == "up")
                {
                    steppedChar = board[--gamblerPos[0], gamblerPos[1]];

                    board[gamblerPos[0], gamblerPos[1]] = 'G';
                    board[gamblerPos[0] + 1, gamblerPos[1]] = '-';
                }
                else if (move == "down")
                {
                    steppedChar = board[++gamblerPos[0], gamblerPos[1]];

                    board[gamblerPos[0], gamblerPos[1]] = 'G';
                    board[gamblerPos[0] - 1, gamblerPos[1]] = '-';
                }
                else if (move == "left")
                {
                    steppedChar = board[gamblerPos[0], --gamblerPos[1]];

                    board[gamblerPos[0], gamblerPos[1]] = 'G';
                    board[gamblerPos[0], gamblerPos[1] + 1] = '-';
                }
                else if (move == "right")
                {
                    steppedChar = board[gamblerPos[0], ++gamblerPos[1]];

                    board[gamblerPos[0], gamblerPos[1]] = 'G';
                    board[gamblerPos[0], gamblerPos[1] - 1] = '-';
                }
                else if (move == "end")
                {
                    EndGame(board, score, false);
                    return false;
                }

                if (steppedChar == 'W')
                {
                    score += 100;
                }
                else if (steppedChar == 'P')
                {
                    score -= 200;

                    if (score <= 0)
                    {
                        EndGame(board, score, false);
                        return false;
                    }
                }
                else if (steppedChar == 'J')
                {
                    score += 100000;
                    EndGame(board, score, true);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Game over! You lost everything!");
                return false;
            }
        }

        private static void EndGame(char[,] board, int score, bool reachedJackpot)
        {
            if (score <= 0)
            {
                Console.WriteLine("Game over! You lost everything!");
                return;
            }
            else if (reachedJackpot)
            {
                Console.WriteLine("You win the Jackpot!");
            }

            Console.WriteLine($"End of the game. Total amount: {score}$");
            PrintMatrix(board);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
