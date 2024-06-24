namespace WildFarm.Models;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        weightIncreaseValue = 0.30;
    }

    public override string ProduceSound() => "Meow";
    
    public override void Eat(Food food)
    {
        if (food is Meat || food is Vegetable)
        {
            base.Eat(food);
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}