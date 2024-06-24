using BorderControl.Interfaces;

namespace BorderControl.Models;
public class Citizen : IIdentifiable
{
	private string name;
	private int age;
	private string id;

	public Citizen(string name, int age, string id)
	{
		Name = name;
        Age = age;
		Id = id;
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
}