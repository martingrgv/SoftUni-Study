namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input;

            // Add guests
            while ((input = Console.ReadLine()) != "PARTY")
            {
                string guest = input;

                if (Char.IsDigit(guest[0])) // if the guest is vip
                    vipGuests.Add(guest);
                else
                    regularGuests.Add(guest);
            }

            // Check guest list
            while ((input = Console.ReadLine()) != "END")
            {
                string guest = input;

                if (vipGuests.Contains(guest))
                    vipGuests.Remove(guest);
                else if (regularGuests.Contains(guest))
                    regularGuests.Remove(guest);
            }

            int missingGuests = vipGuests.Count + regularGuests.Count;

            Console.WriteLine(missingGuests);

            foreach (var vipGuest in vipGuests)
                Console.WriteLine(vipGuest);

            foreach (var regularGuest in regularGuests)
                Console.WriteLine(regularGuest);
        }
    }
}
