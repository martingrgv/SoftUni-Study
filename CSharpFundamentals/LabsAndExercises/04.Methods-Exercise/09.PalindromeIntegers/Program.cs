using System.Collections.Generic;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = GetNumbers();
            
            foreach (var num in numbers)
            {
                Console.WriteLine(isPalindrome(num).ToString().ToLower());
            }
        }

        static List<int> GetNumbers()
        {
            string userInput;
            List<int> list = new List<int>();

            while ((userInput = Console.ReadLine()) != "END")
            {
                list.Add(int.Parse(userInput));
            }

            return list;
        }

        static bool isPalindrome(int num)
        {
            int before = num;
            int after = 0;

            while (num > 0)
            {
                after = after * 10 + num % 10;
                num = num / 10;
            }

            return before == after;
        }
    }
}