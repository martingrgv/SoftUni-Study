namespace _02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float pounds = float.Parse(Console.ReadLine());

            float dollars = pounds * 1.31f;
            Console.WriteLine($"{dollars:f3}");
        }
    }
}