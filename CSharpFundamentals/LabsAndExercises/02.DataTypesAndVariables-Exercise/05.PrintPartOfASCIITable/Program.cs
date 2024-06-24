namespace _05.PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                char asciiValue = ConvertToASCII(i);
                Console.Write(asciiValue + " ");
            }
        }

        static char ConvertToASCII(int number)
        {
            return Convert.ToChar(number);
        }
    }
}