namespace Raiding.Models;

public abstract class BaseHero
{
    private string name;
    private int power;
    
    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name
    {
        get { return name; }
        protected set
        {
            // if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            // {
            //     throw new ArgumentException("Name cannot be null!");
            // }

            name = value;
        }
    }

    public int Power
    {
        get { return power; }
        protected set
        {
            // if (value < 0)
            // {
            //     throw new ArgumentException("Power cannot be negative!");
            // }

            power = value;
        }
    }

    public abstract string CastAbility();
}