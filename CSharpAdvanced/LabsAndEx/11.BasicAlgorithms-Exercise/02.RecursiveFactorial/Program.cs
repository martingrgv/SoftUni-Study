namespace _02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFactorial(n));
        }

        private static long GetFactorial(int n)
        {
            if (n == 0)
                return 1;

            return n * GetFactorial(--n);
        }
    }
}
