namespace _01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int[] numbers = { a, b, c };

            Array.Sort(numbers);
            Array.Reverse(numbers);
            
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}