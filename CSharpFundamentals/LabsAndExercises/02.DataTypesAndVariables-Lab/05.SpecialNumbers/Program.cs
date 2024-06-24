namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i >= 10)
                {
                    int sumOfDigits = 0;
                    int currentNumber = i;

                    // Calculate sum of digits
                    while (currentNumber > 0)
                    {
                        int lastDigit = currentNumber % 10;
                        sumOfDigits += lastDigit;
                        currentNumber = currentNumber / 10;
                    }

                    if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                    {
                        Console.WriteLine("{0} -> True", i);
                    }
                    else
                    {
                        Console.WriteLine("{0} -> False", i);
                    }
                }
                else
                {
                    if (i == 5 || i == 7)
                    {
                        Console.WriteLine("{0} -> True", i);
                    }
                    else
                    {
                        Console.WriteLine("{0} -> False", i);
                    }
                }
            }
        }
    }
}