namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            // Login 
            if (multiplier > 10)
            {
                Console.WriteLine("{0} X {1} = {2}", n, multiplier, n * multiplier);
            }
            else
            {
                for (int i = multiplier; i <= 10; i ++)
                {
                    Console.WriteLine("{0} X {1} = {2}", n, i, n * i);
                }
            }
        }
    }
}