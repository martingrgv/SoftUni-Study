namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string state = ChechNumberState(n);

            Console.WriteLine("The number {0} is {1}.", n, state);
        }

        static string ChechNumberState(int n)
        {
            if (n > 0)
            {
                return "positive";
            }
            else if (n == 0)
            {
                return "zero";
            }
            else
            {
                return "negative";
            }
        }
    }
}