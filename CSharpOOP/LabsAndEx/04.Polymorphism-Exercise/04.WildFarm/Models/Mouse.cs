namespace WildFarm.Models;

public class Mouse : Mammal
{
    
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        weightIncreaseValue = 0.10;
    }

    public override string ProduceSound() => "Squeak";

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}