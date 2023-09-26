namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            // Input
            int interval = int.Parse(Console.ReadLine());

            // Logic
            for (int i = 0; i < interval; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                sum += (int)currentLetter;
            }

            // Output
            Console.WriteLine("The sum equals: {0}", sum);
        }
    }
}