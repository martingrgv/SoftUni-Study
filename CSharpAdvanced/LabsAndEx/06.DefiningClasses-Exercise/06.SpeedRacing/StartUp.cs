namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        var cars = GetCars();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (commandArgs[0] == "Drive")
            {
                string carModel = commandArgs[1];
                double distance = double.Parse(commandArgs[2]);

                cars.FirstOrDefault(c => c.Model == carModel).Drive(distance);
            }
        }

        cars.ForEach(c => Console.WriteLine(c.ToString()));
    }

    private static List<Car> GetCars()
    {
        var cars = new List<Car>();

        int carsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsCount; i++)
        {
            string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carArgs[0];
            double fuelAmount = double.Parse(carArgs[1]);
            double fuelConsumptionPerKilometer = double.Parse(carArgs[2]);

            cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
        }

        return cars;
    }
}
