namespace WildFarm.Models;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        weightIncreaseValue = 0.40;
    }

    public override string ProduceSound() => "Woof!";
    
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