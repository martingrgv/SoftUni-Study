namespace PersonsInfo;

public class Person
{
    private int age;
    private string firstName;
    private string lastName;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        Age = age;
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            age = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            lastName = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < 650)
            {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }

            salary = value;
        }
    }

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