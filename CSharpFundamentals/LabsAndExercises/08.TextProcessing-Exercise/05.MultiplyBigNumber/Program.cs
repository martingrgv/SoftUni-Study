namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            string multiplyer = Console.ReadLine();

            Console.WriteLine(MultiplyBigNumbers(bigNum, multiplyer));
        }

        private static string MultiplyBigNumbers(string number, string multiplyerNumber)
        {
            if (number == "0" || multiplyerNumber == "0")
            {
                return "0";
            }

            int carry = 0;
            int multiplyer = int.Parse(multiplyerNumber);

            char[] resultChar = new char[number.Length + 1];

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());
                int product = digit * multiplyer + carry;

                resultChar[i + 1] = (char)(product % 10 + '0');
                carry = product / 10;
            }

            if (carry > 0)
            {
                resultChar[0] = (char)(carry + '0');
            }

            return new string (resultChar).TrimStart('\0');
        }
    }
}