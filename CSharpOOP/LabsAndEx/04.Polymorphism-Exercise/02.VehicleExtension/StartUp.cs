using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Get vehicles
            string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));

            string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));

            string[] busData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            // Start program 
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (command[0])
                    {
                        case "Drive":
                            if (command[1] == "Car") car.Drive(double.Parse(command[2]));
                            else if (command[1] == "Truck") truck.Drive(double.Parse(command[2]));
                            else if (command[1] == "Bus") bus.Drive(double.Parse(command[2]));
                            break;
                        case "DriveEmpty":
                            bus.DriveWithPeople(double.Parse(command[2]));
                            break;
                        case "Refuel":
                            if (command[1] == "Car") car.Refuel(double.Parse(command[2]));
                            else if (command[1] == "Truck") truck.Refuel(double.Parse(command[2]));
                            else if (command[1] == "Bus") bus.Refuel(double.Parse(command[2]));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
