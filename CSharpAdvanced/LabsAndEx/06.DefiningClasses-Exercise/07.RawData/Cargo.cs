namespace DefiningClasses;

public class Cargo
{
    private CargoType type;
    private double weight;

    public Cargo(CargoType type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public CargoType Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }
}