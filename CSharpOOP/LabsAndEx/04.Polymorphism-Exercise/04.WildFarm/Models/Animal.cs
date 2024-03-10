namespace WildFarm.Models;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;
    protected double weightIncreaseValue;

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name must be set!");
            }

            name = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight cannot be negative!");
            }

            weight = value;
        }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Eaten food count cannot be negative!");
            }

            foodEaten = value;
        }
    }

    public abstract string ProduceSound();

    public virtual void Eat(Food food)
    {
        if (food == null)
        {
            throw new ArgumentException("Food cannot be null!");
        }
        else if (food.Quantity <= 0)
        {
            throw new ArgumentException("Food quantity cannot be zero or negative!");
        }
        else
        {
            Weight += weightIncreaseValue * food.Quantity;
            FoodEaten += food.Quantity;
            food.Quantity = 0;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} ";
    }
}