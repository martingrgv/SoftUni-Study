namespace _01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int sum = firstNum + secondNum;
            int divider = sum / thirdNum;
            int multiplier = divider * fourthNum;

            Console.WriteLine(multiplier);
        }
    }
}