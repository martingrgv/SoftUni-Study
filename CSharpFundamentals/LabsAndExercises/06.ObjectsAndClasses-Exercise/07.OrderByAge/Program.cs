namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] input = Console.ReadLine().Split(" ");

            while (input[0] != "End")
            {
                Person p = GetPerson(input);
                UpdatePerson(people, p);

                input = Console.ReadLine().Split(" ");
            }

            PrintPeople(people);
        }

        static Person GetPerson(string[] input)
        {
            string name = input[0];
            string id = input[1];
            int age = int.Parse(input[2]);

            Person p = new Person(name, id, age);

            return p;
        }

        static void UpdatePerson(List<Person> people, Person p)
        {
            people.Where(person => );


            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Id == p.Id)
                {
                    people[i].Name = p.Name;
                    people[i].Age = p.Age;
                }
                else
                {
                    people.Add(p);
                    break;
                }
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