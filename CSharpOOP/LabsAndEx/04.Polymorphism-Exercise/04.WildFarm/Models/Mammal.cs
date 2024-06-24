namespace WildFarm.Models;

public abstract class Mammal : Animal
{
    private string livingRegion;
    
    protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Living region must be set!");
            }

            livingRegion = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"[{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}