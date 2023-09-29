namespace _05.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            var sumOfEvens = 0;

            foreach (var num in evenNumbers)
            {
                sumOfEvens += num;
            }
            Console.WriteLine(sumOfEvens);
        }
    }
}