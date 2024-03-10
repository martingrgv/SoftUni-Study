namespace WildFarm.Models;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        weightIncreaseValue = 1;
    }

    public override string ProduceSound() => "ROAR!!!";

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