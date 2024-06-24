namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Car> cars = GetCars();
        CargoType cargoType = Console.ReadLine() == "fragile" ? CargoType.Fragile : CargoType.Flammable;

        if (cargoType == CargoType.Fragile)
        {
            cars = cars.Where(c => c.Cargo.Type == CargoType.Fragile && c.Tires.Any(t => t.Pressure < 1)).ToList();
            cars.ForEach(c => Console.WriteLine(c.Model));
            return;
        }

        cars = cars.Where(c => c.Cargo.Type == CargoType.Flammable && c.Engine.Power > 250).ToList();
        cars.ForEach(c => Console.WriteLine(c.Model));
    }

    private static List<Car> GetCars()
    {
        List<Car> cars = new List<Car>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carArgs[0];

            Engine engine = GetEngine(carArgs);
            Cargo cargo = GetCargo(carArgs);
            Tire[] tires = GetTires(carArgs);

            cars.Add(new Car(model, engine, cargo, tires));
        }

        return cars;
    }

    private static Engine GetEngine(string[] carArgs)
    {
        int engineSpeed = int.Parse(carArgs[1]);
        int enginePower = int.Parse(carArgs[2]);

        return new Engine(enginePower, engineSpeed);
    }

    private static Cargo GetCargo(string[] carArgs)
    {
        CargoType cargoType = carArgs[4] == "fragile" ? CargoType.Fragile : CargoType.Flammable;
        double cargoWeight = double.Parse(carArgs[3]);

        return new Cargo(cargoType, cargoWeight);
    }

    private static Tire[] GetTires(string[] carArgs)
    {
        double tire1Pressure = double.Parse(carArgs[5]);
        int tire1Age = int.Parse(carArgs[6]);

        double tire2Pressure = double.Parse(carArgs[7]);
        int tire2Age = int.Parse(carArgs[8]);

        double tire3Pressure = double.Parse(carArgs[9]);
        int tire3Age = int.Parse(carArgs[10]);

        double tire4Pressure = double.Parse(carArgs[11]);
        int tire4Age = int.Parse(carArgs[12]);

        return new Tire[4]
        {
            new Tire(tire1Age, tire1Pressure),
            new Tire(tire2Age, tire2Pressure),
            new Tire(tire3Age, tire3Pressure),
            new Tire(tire4Age, tire4Pressure)
        };
    }

}
