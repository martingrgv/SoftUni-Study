namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int n = int.Parse(Console.ReadLine());

            // Logic
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0} X {1} = {2}", n, i, n * i);
            }
        }
    }
}