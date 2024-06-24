namespace _03.NeedForSpeedIII;

class Program
{
    private static List<Car> cars = new List<Car>();

    static void Main(string[] args)
    {
        int carsCount = int.Parse(Console.ReadLine());
        AddCars(carsCount);

        string input;
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] commandArgs = input.Split(" : ");
            switch(commandArgs[0])
            {
                case "Drive":
                    string carName = commandArgs[1];
                    int travelDistance = int.Parse(commandArgs[2]);
                    int fuelConsumption = int.Parse(commandArgs[3]);

                    Car car = GetCarByName(carName);
                    car.Drive(travelDistance, fuelConsumption);

                    // Change car
                    if (car.Mileage > 100000)
                    {
                        cars.Remove(car);
                        System.Console.WriteLine($"Time to sell the {car.Name}");
                    }
                    break;
                case "Refuel":
                    carName = commandArgs[1];
                    int fuel = int.Parse(commandArgs[2]);

                    car = GetCarByName(carName);
                    car.Refuel(fuel);
                    break;
                case "Revert":
                    carName = commandArgs[1];
                    int kilometers = int.Parse(commandArgs[2]);

                    car = GetCarByName(carName);
                    car.Revert(kilometers);
                    break;
            }
        }

        // Print cars
        cars.ForEach(c => System.Console.WriteLine($"{c.Name} -> Mileage: {c.Mileage} kms, Fuel in the tank: {c.Fuel} lt."));
    }

    private static void AddCars(int count)
    {
        while (count > 0)
        {
            Car car = GetCar();
            cars.Add(car);

            count--;
        }
    }

    private static Car GetCar()
    {
        string[] carArguments = Console.ReadLine().Split('|');
        string name = carArguments[0];
        int mileage = int.Parse(carArguments[1]);
        int fuel = int.Parse(carArguments[2]);

        return new Car(name, mileage, fuel);
    }

    private static Car GetCarByName(string name) => cars.FirstOrDefault(c => c.Name == name);
}