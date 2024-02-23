namespace PersonsInfo;

public class Person
{
	private int age;

	public Person(string firstName, string lastName, int age)
	{
		FirstName = firstName;
		LastName = lastName;
		Age = age;
	}

	public string FirstName { get; private set; }
    public string LastName { get; private set; }
	public int Age
	{
		get { return age; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Age cannot be a negative number.");
			}

			age = value;
		}
	}

    public override string ToString()
    {
		return $"{FirstName} {LastName} is {Age} years old.";
    }
}