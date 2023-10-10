namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();

            if (inputType == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                int max = GetMax(a, b);
                Console.WriteLine(max);
            }
            else if (inputType == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());

                char max = GetMax(a, b);
                Console.WriteLine(max);
            }
            else
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();

                string max = GetMax(a, b);
                Console.WriteLine(max);
            }    

        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }
        static char GetMax(char a, char b)
        {
            return a > b ? a : b;
        }
        static string GetMax(string a, string b)
        {
            return a.CompareTo(b) == 1 ? a : b;
        }
    }
}