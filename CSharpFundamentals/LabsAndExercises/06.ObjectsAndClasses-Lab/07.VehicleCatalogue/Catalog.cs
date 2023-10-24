namespace Vehicles.Collections;

public class Catalog
{
    List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicles(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void PrintCatalog()
    {
        if (vehicles.Any(v => v is Car))
        {
            List<Car> cars = vehicles.OfType<Car>().ToList();
            List<Car> orderedCars = cars.OrderBy(c => c.Brand).ToList();

            System.Console.WriteLine("Cars:");

            foreach (Car car in orderedCars)
            {
                System.Console.WriteLine($"{car.Brand}: {car.Model} - {car.HP}hp");
            }
        }

        if (vehicles.Any(v => v is Truck))
        {
            List<Truck> trucks = vehicles.OfType<Truck>().ToList();
            List<Truck> orderedTrucks = trucks.OrderBy(t => t.Brand).ToList();

            System.Console.WriteLine("Trucks:");

            foreach (Truck truck in orderedTrucks)
            {
                System.Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}