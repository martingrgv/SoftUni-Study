namespace Catch;

public class StartUp
{
    public static void Main(string[] args)
    {
        ManipulativeIntArray manipulativeArr = new ManipulativeIntArray(Console.ReadLine()
                                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                                .Select(int.Parse)
                                                                .ToArray());

        int exceptionsCount = 0;

        while (exceptionsCount < 3)
        {
            string[] command = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (command[0])
                {
                    case "Replace":
                        manipulativeArr.Replace(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Show":
                        manipulativeArr.Show(int.Parse(command[1]));
                        break;
                    case "Print":
                        manipulativeArr.Print(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The variable is not in the correct format!");
                exceptionsCount++;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                exceptionsCount++;
            }
        }

        Console.WriteLine(manipulativeArr);
    }
}