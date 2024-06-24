namespace DelegateCalculator
{
    internal class Program
    {
        // Single cast deligate
        public delegate int Calculator(int a, int b);

        static void Main(string[] args)
        {
            // Enter in format a + b

            Console.WriteLine("Operations: +|-|*|/|?");

            string[] input = Console.ReadLine().Split();

            int a = int.Parse(input[0]);
            int b = int.Parse(input[2]);

            string operation = input[1];

            Calculator add = (int a, int b) => a + b;
            Calculator sub = (int a, int b) => a - b;
            Calculator mul = (int a, int b) => a * b;
            Calculator div = (int a, int b) => a / b;

            switch(operation)
            {
                case "+":
                    Console.WriteLine(add(a, b));
                    break;
                case "-":
                    Console.WriteLine(sub(a, b));
                    break;
                case "*":
                    Console.WriteLine(mul(a, b));
                    break;
                case "/":
                    Console.WriteLine(div(a, b));
                    break;
            }
        }

    }
}
