namespace WildFarm.Models;

public abstract class Feline : Mammal 
{
    private string breed;
    
    protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed
    {
        get { return breed; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Breed must be set!");
            }

            breed = value;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}