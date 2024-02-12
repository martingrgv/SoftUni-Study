namespace _05.ComparingObjects;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public int CompareTo(Person? other)
    {
        int nameComparar = this.Name.CompareTo(other.Name);

        if (nameComparar == 0)
        {
            int ageComparer = this.Age.CompareTo(other.Age);

            if (ageComparer == 0)
            {
                return this.Town.CompareTo(other.Town);
            }

            return ageComparer;
        }

        return nameComparar;
    }
}