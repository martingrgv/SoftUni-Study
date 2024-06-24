namespace _05.ComparingObjects;
class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        // Add people
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            people.Add(new Person(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]));
        }

        // Compare people
        int n = int.Parse(Console.ReadLine());
        Person comparePerson = people[n - 1];

        people.RemoveAt(n - 1);

        int equalCount = 0;
        int differentCount = 0;

        foreach (var person in people)
        {
            if (person.CompareTo(comparePerson) == 0)
            {
                equalCount++;
            }
            else
            {
                differentCount++;
            }
        }

        if (equalCount == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalCount + 1} {differentCount} {people.Count + 1}");
        }
    }
}

