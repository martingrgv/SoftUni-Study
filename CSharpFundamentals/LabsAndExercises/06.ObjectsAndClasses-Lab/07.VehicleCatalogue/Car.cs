namespace Vehicles;

public class Car : Vehicle
{
    public double HP { get; set; }

    public Car (string brand, string model, double hp)
    {
        Brand = brand;
        Model = model;
        HP = hp;
    }
}
