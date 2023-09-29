namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToArray();
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            var oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

            int evenNumbersSum = GetElemetsSum(evenNumbers);
            int oddNumbersSum = GetElemetsSum(oddNumbers);
            int diff = evenNumbersSum - oddNumbersSum;

            Console.WriteLine(diff);
        }

        static int GetElemetsSum(int[] arr)
        {
            int sum = 0;
            foreach (var num in arr)
            {
                sum += num;
            }
            return sum;
        }
    }
}