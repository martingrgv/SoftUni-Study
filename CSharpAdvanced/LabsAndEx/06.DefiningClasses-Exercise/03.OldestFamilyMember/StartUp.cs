namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] personArgs = Console.ReadLine().Split();

            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);

            family.AddMember(new Person(name, age));
        }

        Person oldestPerson = family.GetOldestMember();

        Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
    }
}
