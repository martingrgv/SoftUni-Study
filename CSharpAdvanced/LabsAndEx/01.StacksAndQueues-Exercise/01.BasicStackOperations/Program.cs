namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int pushCount = int.Parse(input[0]);
            int popCount = int.Parse(input[1]);
            int searchElement = int.Parse(input[2]);

            input = Console.ReadLine().Split();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < pushCount; i++) // Push to stack
            {
                stack.Push(int.Parse(input[i]));
            }

            for (int i = 0; i < popCount; i++) // Pop from stack
            {
                if (stack.Count > 0)
                    stack.Pop();
            }


            Stack<int> searchStack = new Stack<int>(stack);
            while (searchStack.Count > 0) // Search for element
            {
                int element = searchStack.Pop();

                if (element == searchElement)
                {
                    Console.WriteLine("true");
                    return;
                }
            }

            if (stack.Count > 0)
            {
                int smallestElement = stack.Pop();
                while (stack.Count > 0) // Get smallest element
                {
                    int element = stack.Pop();

                    if (element < smallestElement)
                    {
                        smallestElement = element;
                    }
                }

                Console.WriteLine(smallestElement);
                return;
            }

            Console.WriteLine(0);
        }
    }
}
