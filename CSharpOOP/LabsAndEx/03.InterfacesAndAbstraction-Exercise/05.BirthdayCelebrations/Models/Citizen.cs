using Celebration.Interfaces;

namespace Celebration.Models;
public class Citizen : IIdentifiable, ILiving
{
	private string name;
	private int age;
    private DateOnly birthdate;
	private string id;

	public Citizen(string name, int age, string id, DateOnly birthdate)
	{
		Name = name;
        Age = age;
		Id = id;
        Birthdate = birthdate;
	}

	public string Name
	{
		get { return name; }
		private set
		{
			if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Name cannot be empty!");
			}

			name = value;
		}
	}

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Id cannot be empty!");
            }

            age = value;
        }
    }

    public string Id
    {
        get { return id; }
        set
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Id cannot be empty!");
            }

            id = value;
        }
    }

    public DateOnly Birthdate
    {
        get { return birthdate; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentException("Bithdate cannot be null!");
            }

            birthdate = value;
        }
    }
}