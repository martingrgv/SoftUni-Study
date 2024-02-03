namespace DefiningClasses;

public class Family
{
    private List<Person> people;

    public Family()
    {
        People = new List<Person>();
    }

    public List<Person> People
    {
        get { return this.people; }
        set { this.people = value; }
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember() => people.MaxBy(p => p.Age);
}