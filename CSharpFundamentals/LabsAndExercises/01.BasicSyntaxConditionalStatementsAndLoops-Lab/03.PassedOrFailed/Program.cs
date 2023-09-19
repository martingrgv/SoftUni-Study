namespace _03.PassedOrFailed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            double grade = double.Parse(Console.ReadLine());

            // Output
            if (grade >= 3.00) Console.WriteLine("Passed!");
            else Console.WriteLine("Failed!");
        }
    }
}