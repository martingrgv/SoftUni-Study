namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        var people = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personArgs = Console.ReadLine().Split();

            string name = personArgs[0];
            int age = int.Parse(personArgs[1]);

            people.Add(new Person(name, age));
        }

        people = people.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();

        people.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
    }
}
