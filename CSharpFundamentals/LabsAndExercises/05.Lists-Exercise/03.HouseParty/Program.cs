namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] userInput = Console.ReadLine().Split(" ");
                string name = userInput[0];

                if (userInput[2] == "going!")
                {
                    if (!guests.Contains(name))
                    {
                       guests.Add(name);
                    }
                    else if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }    
                }
                else // Is not going
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", guests));
        }
    }
}