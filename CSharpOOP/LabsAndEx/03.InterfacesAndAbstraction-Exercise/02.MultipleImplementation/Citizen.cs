namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
	private int age;
	private string id;
	private string birthdate;

	public Citizen(string name, int age, string id, string birthdate)
	{
		Name = name;
		Age = age;
		Id = id;
		Birthdate = birthdate;
	}

    public string Name { get; set; }

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

    public string Id
	{
		get { return id; }
		private set
		{
			if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Id cannot be empty.");
			}

			id = value;
		}
	}

    public string Birthdate
	{
		get { return birthdate; }
		private set
		{
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Id cannot be empty.");
            }

			birthdate = value;
        }
	}

    public override string ToString()
    {
		return Id
            + Environment.NewLine
			+ Birthdate;
    }
}