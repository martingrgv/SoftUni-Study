namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] calculator = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Array.Reverse(calculator);
            var stack = new Stack<string>(calculator);

            int sum = int.Parse(stack.Pop());

            while (stack.Count > 0) // Loop through acts
            {
                string @operator = stack.Pop();
                int num = int.Parse(stack.Pop());

                switch(@operator) // Do math operation
                {
                    case "+":
                        sum += num;
                        break;
                    case "-":
                        sum -= num;
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
