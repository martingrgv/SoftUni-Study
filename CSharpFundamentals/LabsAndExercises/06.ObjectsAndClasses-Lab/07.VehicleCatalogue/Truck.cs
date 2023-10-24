namespace Vehicles;

public class Truck : Vehicle
{
    public double Weight { get; set; }

    public Truck (string brand, string model, double weight)
    {
        Brand = brand;
        Model = model;
        Weight = weight;
    }
}
