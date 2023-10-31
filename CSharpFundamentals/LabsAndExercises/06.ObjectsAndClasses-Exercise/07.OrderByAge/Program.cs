namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string? input;
            while ((input = Console.ReadLine()) != "End")
            {
                Person p = GetPerson(input);

                if (PersonIdExists(p, people))
                {
                    UpdatePerson(p, people);
                }
                else
                {
                    people.Add(p);
                }
            }

            PrintPeople(people);
        }

        static Person GetPerson(string input)
        {
            string[] arguments = input.Split(" ");
            string name = arguments[0];
            string id = arguments[1];
            int age = int.Parse(arguments[2]);

            return new Person(name, id, age);
        }

        static Person? GetPersonById(Person p, List<Person> people)
        {
            return people.Find(person => person.Id == p.Id);
        }

        static bool PersonIdExists(Person p, List<Person> people)
        {
            return people.Any(person => person.Id == p.Id);
        }

        static void UpdatePerson(Person p, List<Person> people)
        {
            Person? foundPerson = GetPersonById(p, people);

            if (foundPerson != null)
            {
                foundPerson.Name = p.Name;
                foundPerson.Age = p.Age;
            }
        }

        static void PrintPeople(List<Person> people)
        {
            people = people.OrderBy(p => p.Age).ToList();
            
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}