using System.Diagnostics;

namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // Slower but shorter
            char[] chArr = input.ToCharArray();

            var digits = chArr.Where(char.IsDigit);
            var letters = chArr.Where(char.IsLetter);
            var  characters = chArr.Where(ch => !char.IsDigit(ch) && !char.IsLetter(ch));

            Console.WriteLine(string.Join("", digits) + "\n" + string.Join("", letters) + "\n" + string.Join("", characters));

            // Faster but longer
            //string digits = string.Empty;
            //string letters = string.Empty;
            //string characters = string.Empty;

            //foreach (char ch in input)
            //{
            //    if (char.IsDigit(ch))
            //    {
            //        digits += ch;
            //    }
            //    else if (char.IsLetter(ch))
            //    {
            //        letters += ch;
            //    }
            //    else
            //    {
            //        characters += ch;
            //    }
            //}

            //Console.WriteLine(digits + "\n" + letters + "\n" + characters);
        }
    }
}