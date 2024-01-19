namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = ReadArray(rows); // Populate array

            jaggedArray = AnalyzeArray(jaggedArray);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (row < 0 || row >= jaggedArray.Length || // if out of range continue;
                    col < 0 || col >= jaggedArray[row].Length)
                {
                    continue;
                }

                switch (commandArgs[0])
                {
                    case "Add":
                        jaggedArray[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedArray[row][col] -= value;
                        break;
                }
            }

            // Print array
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[][] ReadArray(int rows)
        {

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = numbers;
            }

            return jaggedArray;
        }

        private static int[][] AnalyzeArray(int[][] jaggedArray)
        {
            int rows = jaggedArray.Length;

            for (int row = 0; row < rows - 1; row++)
            {
                string operation;

                if (jaggedArray[row].Length == jaggedArray[row + 1].Length) // if equal in length
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row  + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++) // Top array
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++) // Bottom array
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            return jaggedArray;
        }
    }
}
