namespace PersonsInfo;

public class Person
{
	private int age;

	public Person(string firstName, string lastName, int age, decimal salary)
	{
		FirstName = firstName;
		LastName = lastName;
		Age = age;
		Salary = salary;
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
	public decimal Salary { get; private set; }

	public void IncreaseSalary(decimal percentage)
	{
		if (Age <= 30)
		{
			percentage /= 2;
		}

		Salary += Salary * percentage / 100;
	}

    public override string ToString()
    {
		return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }
}