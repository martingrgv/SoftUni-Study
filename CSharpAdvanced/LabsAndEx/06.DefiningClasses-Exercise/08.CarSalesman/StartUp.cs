namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Car> cars = GetCars();

        cars.ForEach(c => Console.WriteLine(c.ToString()));
    }

    private static Engine GetEngine(string input)
    {
        string[] engineArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string model = engineArgs[0];
        int power = int.Parse(engineArgs[1]);

        Engine engine = new Engine(model, power);

        if (engineArgs.Length == 3)
        {
            if (int.TryParse(engineArgs[2], out int displacement))
            {
                engine.Displacement = displacement;
            }
            else
            {
                string efficiency = engineArgs[2];
                engine.Efficiency = efficiency;
            }
        }
        else if (engineArgs.Length == 4)
        {
            int displacement = int.Parse(engineArgs[2]);
            string efficiency = engineArgs[3];

            engine.Displacement = displacement;
            engine.Efficiency = efficiency;
        }

        return engine;
    }

    private static List<Engine> GetEngines()
    {
        List<Engine> engines = new List<Engine>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();

            Engine engine = GetEngine(input);
            engines.Add(engine);
        }

        return engines;
    }

    private static Car GetCar(string input, List<Engine> engines)
    {
        string[] carArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string model = carArgs[0];
        string engineModel = carArgs[1];

        Car car = new Car(model, engines.FirstOrDefault(e => e.Model == engineModel));

        if (carArgs.Length == 3)
        {
            if (int.TryParse(carArgs[2], out int weight))
            {
                car.Weight = weight;
            }
            else
            {
                string color = carArgs[2];
                car.Color = color;
            }
        }
        else if (carArgs.Length == 4)
        {
            int weight = int.Parse(carArgs[2]);
            string color = carArgs[3];

            car.Weight = weight;
            car.Color = color;
        }

        return car;
    }

    private static List<Car> GetCars()
    {
        List<Engine> engines = GetEngines();
        List<Car> cars = new List<Car>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();

            Car car = GetCar(input, engines);
            cars.Add(car);
        }

        return cars;
    }
}   
