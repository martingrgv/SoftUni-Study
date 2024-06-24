namespace _01.ListyIterator;

public class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch(commandArgs[0])
            {
                case "Create":
                    listyIterator = new ListyIterator<string>(commandArgs.Skip(1).ToList());
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Invalid Operation!");
                    }
                    break;
            }
        }
    }
}
