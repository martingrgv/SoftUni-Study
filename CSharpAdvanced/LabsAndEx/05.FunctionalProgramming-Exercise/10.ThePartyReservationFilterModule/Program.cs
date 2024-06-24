namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                                  .Split(' ',
                                  StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            List<string> removedGuests = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commands = input.Split(';',
                                  StringSplitOptions.RemoveEmptyEntries);

                Predicate<string> filter = GetPredicate(commands[1], commands[2]);

                switch(commands[0])
                {
                    case "Add filter":
                        removedGuests.AddRange(guests.Where(x => filter(x)));
                        guests.RemoveAll(filter);
                        break;
                    case "Remove filter":
                        guests.AddRange(removedGuests.Where(x => filter(x)));
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }

        private static Predicate<string> GetPredicate(string filterType, string filterParam)
        {
            switch(filterType)
            {
                case "Starts with":
                    return g => g.StartsWith(filterParam);
                case "Ends with":
                    return g => g.EndsWith(filterParam);
                case "Length":
                    return g => g.Length == int.Parse(filterParam);
                case "Contains":
                    return g => g.Contains(filterParam);
            }

            return x => true;
        }
    }
}
