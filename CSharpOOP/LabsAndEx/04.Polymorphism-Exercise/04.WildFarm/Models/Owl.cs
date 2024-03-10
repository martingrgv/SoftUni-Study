namespace WildFarm.Models;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        weightIncreaseValue = 0.25;
    }

    public override string ProduceSound() => "Hoot Hoot";
    
    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}