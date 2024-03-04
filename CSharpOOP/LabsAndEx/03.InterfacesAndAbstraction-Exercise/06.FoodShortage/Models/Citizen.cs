using FoodShortage.Interfaces;

namespace FoodShortage.Models;
public class Citizen : Person, IIdentifiable 
{
    private string id;
    private DateOnly birthdate;
    private int food;

    public Citizen(string name, int age, string id, DateOnly birthdate) : base(name, age)
    {
        Id = id;
        Birthdate = birthdate;
        Food = 0;
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

    public override int Food
    {
        get { return food; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Food cannot be a negative number!");
            }

            food = value;
        }
    }

    public override void BuyFood()
    {
        Food += 10;
    }
}