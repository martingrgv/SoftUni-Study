namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char lastCh = char.Parse(Console.ReadLine());

            if (firstCh < lastCh)
                PrintASCII(firstCh, lastCh);
            else
                PrintASCII(lastCh, firstCh);
        }

        static void PrintASCII(char start, char end)
        {
            char currentChar = (char)(start + 1);
            while (currentChar != end)
            {
                Console.Write(currentChar++ + " ");
            }
        }
    }
}