using Vehicles;
using Vehicles.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        string[] input = Console.ReadLine().Split("/");

        while (input[0] != "end")
        {
            Vehicle vehicle = GetVehicle(input);
            catalog.AddVehicles(vehicle);

            input = Console.ReadLine().Split("/");
        }

        catalog.PrintCatalog();
    }

    static Vehicle GetVehicle(string[] input)
    {

        Vehicle vehicle = new Vehicle();
        vehicle.Type = input[0];

        if (vehicle.Type == "Car")
        {
            Car car = GetCar(input);
            return car;
        }
        else // Truck
        {
            Truck truck = GetTruck(input);
            return truck;
        }
    }

    static Car GetCar(string[] input)
    {
        string brand = input[1];
        string model = input[2];
        double hp = double.Parse(input[3]);

        Car car = new Car(brand, model, hp);

        return car;
    }

    static Truck GetTruck(string[] input)
    {
        string brand = input[1];
        string model = input[2];
        double weight = double.Parse(input[3]);

        Truck truck = new Truck(brand, model, weight);

        return truck;
    }
}