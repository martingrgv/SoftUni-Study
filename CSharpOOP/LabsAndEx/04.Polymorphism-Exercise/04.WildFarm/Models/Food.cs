namespace WildFarm.Models;

public abstract class Food
{
    private int quantity;

    protected Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity cannot be negative!");
            }

            quantity = value;
        }
    }
}