namespace _06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];
            
            for (int row = 0; row < jaggedArray.Length; row++) // Add numbers to array
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inArgs = input.Split();

                switch (inArgs[0])
                {
                    case "Add":
                        OperateJaggedArray(jaggedArray, inArgs, "Add");
                        break;
                    case "Subtract":
                        OperateJaggedArray(jaggedArray, inArgs, "Subtract");
                        break;
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        private static void OperateJaggedArray(int[][] jaggedArray, string[] args, string operation)
        {
            int row = int.Parse(args[1]);
            int col = int.Parse(args[2]);
            int value = int.Parse(args[3]);

            if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
            {
                    if (operation == "Add")
                        jaggedArray[row][col] += value;
                    else
                        jaggedArray[row][col] -= value;
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        private static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
