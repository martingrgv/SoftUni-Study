namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] arguments = command.Split();

                switch (arguments[0].ToLower())
                {
                    case "add":
                        stack.Push(int.Parse(arguments[1]));
                        stack.Push(int.Parse(arguments[2]));
                        break;
                    case "remove":
                        int count = int.Parse(arguments[1]);

                        if (stack.Count >= count)
                        {
                            while (count > 0) 
                            {
                                stack.Pop();
                                count--;
                            }
                        }

                        break;
                }
            }

            // Print sum of elements
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
