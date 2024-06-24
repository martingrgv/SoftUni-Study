namespace CarManufacturer;

public class StartUp
{
    static void Main()
    {
        List<Car> carsCollection = GetCars();

        // Find special cars
        var specialCars = carsCollection
                          .Where(c => c.Year >= 2017 &&
                                 c.Engine.HorsePower > 330 &&
                                 c.Tires.Sum(t => t.Pressure) >= 9 &&
                                 c.Tires.Sum(t => t.Pressure) <= 10)
                          .ToList();

        // Show special cars
        foreach (var specialCar in specialCars)
        {
            specialCar.Drive(20);
            Console.WriteLine(specialCar.WhoAmI());
        }
    }

    private static List<Tire[]> GetTires()
    {
        var tiresCollection = new List<Tire[]>();

        string input;
        while ((input = Console.ReadLine()) != "No more tires")
        {
            string[] tireArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var tires = new Tire[4]
            {
                new Tire(int.Parse(tireArgs[0]), double.Parse(tireArgs[1])),
                new Tire(int.Parse(tireArgs[2]), double.Parse(tireArgs[3])),
                new Tire(int.Parse(tireArgs[4]), double.Parse(tireArgs[5])),
                new Tire(int.Parse(tireArgs[6]), double.Parse(tireArgs[7]))
            };

            tiresCollection.Add(tires);
        }

        return tiresCollection;
    }

    private static List<Engine> GetEngines()
    {
        var engines = new List<Engine>();

        string input;
        while((input = Console.ReadLine()) != "Engines done")
        {
            string[] engineArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int hp = int.Parse(engineArgs[0]);
            double cc = double.Parse(engineArgs[1]);

            var engine = new Engine(hp, cc);
            engines.Add(engine);
        }

        return engines;
    }

    private static List<Car> GetCars()
    {
        List<Tire[]> tiresCollection = GetTires();
        List<Engine> enginesCollection = GetEngines();

        List<Car> cars = new List<Car>();

        string input;
        while ((input = Console.ReadLine()) != "Show special")
        {
            string[] carArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string make = carArgs[0];
            string model = carArgs[1];
            int year = int.Parse(carArgs[2]);
            double fuelQuantity = double.Parse(carArgs[3]);
            double fuelConsumption = double.Parse(carArgs[4]);
            int engineIndex = int.Parse(carArgs[5]);
            int tiresIndex = int.Parse(carArgs[6]);

            if (tiresIndex < 0 || tiresIndex >= tiresCollection.Count)
                continue;
            else if (engineIndex < 0 || engineIndex >= enginesCollection.Count)
                continue;

            Engine engine = enginesCollection[engineIndex];
            Tire[] tires = tiresCollection[tiresIndex];

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
            cars.Add(car);
        }

        return cars;
    }
}
