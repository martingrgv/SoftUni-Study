namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command.Split();

                Predicate<string> predicate = GetPredicate(commandArgs);

                switch (commandArgs[0])
                {
                    case "Double":
                        guests = Double(guests, predicate);
                        break;
                    case "Remove":
                        guests = Remove(guests, predicate);
                        break;
                }
            }

            if (guests.Count <= 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }

            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }

        private static Predicate<string> GetPredicate(string[] commandArgs)
        {
            string act = commandArgs[1];

            if (act == "StartsWith")
            {
                return g => g.StartsWith(commandArgs[2]);
            }
            else if (act == "EndsWith")
            {

                return g => g.EndsWith(commandArgs[2]);
            }
            else if (act == "Length")
            {
                int len = int.Parse(commandArgs[2]);
                return g => g.Length == len;
            }

            return null;
        }

        private static List<string> Double(List<string> guests, Predicate<string> predicate)
        {
            List<string> result = new List<string>(guests);

            foreach (var guest in guests)
            {
                if (predicate(guest))
                {
                    result.Add(guest);
                }
            }

            return result;
        }

        private static List<string> Remove(List<string> guests, Predicate<string> predicate)
        {
            List<string> result = new List<string>(guests);

            foreach (var guest in guests)
            {
                if (predicate(guest))
                {
                    result.Remove(guest);
                }
            }

            return result;
        }
    }
}
