using Celebration.Interfaces;

namespace Celebration.Models;
public class Pet : ILiving
{
	private string name;
    private DateOnly birthdate;

	public Pet(string name, DateOnly birthdate)
	{
		Name = name;
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