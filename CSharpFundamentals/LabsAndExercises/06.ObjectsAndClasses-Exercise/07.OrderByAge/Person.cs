internal class Person
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }

    public Person(string name, string id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} with ID: {Id} is {Age} years old.";
    }
}
