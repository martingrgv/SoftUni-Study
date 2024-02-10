namespace _03.Stack;
class Program
{
    static void Main(string[] args)
    {
        CustomStack<int> customStack = new CustomStack<int>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch(commandArgs[0])
            {
                case "Push":
                    int[] pushElements = command
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Skip(1)
                                        .Select(int.Parse)
                                        .ToArray();

                    customStack.Push(pushElements);
                    break;
                case "Pop":
                    try
                    {
                        customStack.Pop();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("No elements");
                    }
                    break;
            }
        }

        PrintTwice(customStack);
    }

    private static void PrintTwice<T>(CustomStack<T> stack)
    {
        for (int i = 0; i < 2; i++)
            foreach (var item in stack)
                Console.WriteLine(item);
    }
}