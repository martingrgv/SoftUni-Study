namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double lastNum = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNum, @operator, lastNum));
        }

        static double Calculate(double a, char @operator, double b)
        {
            double result = 0;
            switch (@operator)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
            }

            return result;
        }
    }
}