namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int fN = int.Parse(Console.ReadLine());
            int lN = int.Parse(Console.ReadLine());

            Calculate(fN, lN, operation);
        }

        static void Calculate(int firstNumber, int lastNumber, string operation)
        {
            if (operation == "add")
            {
                Console.WriteLine(firstNumber + lastNumber);
            }
            else if (operation == "subtract")
            {
                Console.WriteLine(firstNumber - lastNumber);
            }
            else if (operation == "multiply")
            {
                Console.WriteLine(firstNumber * lastNumber);
            }
            else
            {
                Console.WriteLine(firstNumber / lastNumber);
            }
        }
    }
}