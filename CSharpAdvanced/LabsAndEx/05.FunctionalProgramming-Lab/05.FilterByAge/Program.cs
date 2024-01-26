namespace _05.FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new Person(name, age));       
            }

            return people;
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            switch (condition)
            {
                case "younger":
                    return p => p.Age < ageThreshold;
                case "older":
                    return p => p.Age >= ageThreshold;
            }

            return null;
        }

        private static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine(p.Name);
                case "age":
                    return p => Console.WriteLine(p.Age);
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }

            return null;
        }

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> format, Action<Person> printer)
        {
            foreach (var person in people)
            {
                if (format(person))
                {
                    printer(person);
                }
            }
        }
    }
}
