namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int finishNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < finishNum; i++)
            {
                char firstChar = (char)('a' + i);
                for (int j = 0; j < finishNum; j++)
                {
                    char secondChar = (char)('a' + j);
                    for (int k = 0; k < finishNum; k++)
                    {
                        char thirdChar = (char)('a' + k);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}