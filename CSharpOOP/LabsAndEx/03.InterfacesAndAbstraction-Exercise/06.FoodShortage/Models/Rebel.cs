namespace FoodShortage.Models;

public class Rebel : Person 
{
    private string group;
    private int food;
    
    public Rebel(string name, int age, string group) : base(name, age)
    {
        Group = group;
        Food = 0;
    }

    public string Group
    {
        get { return group; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Cannot assign group that has no name!");
            }

            group = value;
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
        Food += 5;
    }
}
