using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Participant
    {
        public string Name { get; set; }
        public uint Distance { get; set; }

        public Participant()
        {
            // Empty Constructor
        }

        public Participant(string name)
        {
            Name = name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = GetParticipants();

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = GetName(input);
                uint distance = GetDistance(input);

                Participant participant = participants.FirstOrDefault(p => p.Name == name);
                if (participant != null)
                {
                    participant.Distance += distance;
                }
            }

            PrintParticipants(participants);
        }

        static List<Participant> GetParticipants()
        {
            string[] participantNames = Console.ReadLine().Split(", ");
            List<Participant> participants = new List<Participant>();

            foreach (string name in participantNames)
            {
                if (!participants.Any(p => p.Name == name))
                {
                    Participant p = new Participant(name);
                    participants.Add(p);
                }
            }

            return participants;
        }

        private static string GetName(string input)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"[A-Za-z]";
            foreach (Match match in Regex.Matches(input, pattern))
            {
                sb.Append(match.Value);
            }

            return sb.ToString();
        }

        private static uint GetDistance(string input)
        {
            uint distance = 0;

            string pattern = @"\d";
            foreach (Match match in Regex.Matches(input, pattern))
            {
                distance += uint.Parse(match.Value);
            }

            return distance;
        }

        private static void PrintParticipants(List<Participant> participants)
        {
            List<Participant> topParticipants = participants.OrderByDescending(p => p.Distance).Take(3).ToList();

            Console.WriteLine($"1st place: {topParticipants[0].Name}");
            Console.WriteLine($"2nd place: {topParticipants[1].Name}");
            Console.WriteLine($"3rd place: {topParticipants[2].Name}");
        }
    }
}