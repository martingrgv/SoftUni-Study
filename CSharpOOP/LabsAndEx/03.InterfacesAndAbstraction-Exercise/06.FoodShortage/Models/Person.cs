using FoodShortage.Interfaces;

namespace FoodShortage.Models;

public abstract class Person : IBuyer
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null!");
            }

            name = value;
        }
    }
    
    public int Age
    {
        get { return age; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative!");
            }

            age = value;
        }
    }

    public abstract int Food {  get; protected set; }

    public abstract void BuyFood();
}