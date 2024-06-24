using System.Text;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                sb.AppendLine(input + " = " + string.Join("", input.Reverse()));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}