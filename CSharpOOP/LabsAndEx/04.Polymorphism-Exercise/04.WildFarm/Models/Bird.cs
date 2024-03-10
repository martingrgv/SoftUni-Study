namespace WildFarm.Models;

public abstract class Bird : Animal
{
    private double wingSize;
    
    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize
    {
        get { return wingSize; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Wing size cannot be negative!");
            }
        
            wingSize = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"[{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}