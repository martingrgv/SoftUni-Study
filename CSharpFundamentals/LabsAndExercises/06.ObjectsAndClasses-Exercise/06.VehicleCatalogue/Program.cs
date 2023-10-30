namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = GetVehicles();

            PrintVehicleDetails(vehicles);
            PrintAverageHP(vehicles);
        }

        static List<Vehicle> GetVehicles()
        {
            string input;
            List<Vehicle> vehicles = new List<Vehicle>();
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(" ");
                string type = arguments[0];
                string model = arguments[1];
                string color = arguments[2];
                int hp = int.Parse(arguments[3]);

                Vehicle vehicle = new Vehicle(type, model, color, hp);
                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        static Vehicle FindVehicle(string model, List<Vehicle> vehicles)
        {
            return vehicles.Find(v => v.Model == model);
        }

        static void PrintVehicleDetails(List<Vehicle> vehicles)
        {
            string input;

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                string model = input;
                Vehicle vehicle = FindVehicle(model, vehicles);

                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
        }

        static void PrintAverageHP(List<Vehicle> vehicles)
        {
            PrintCarsHP(vehicles);
            PrintTrucksHP(vehicles);
        }

        static void PrintCarsHP(List<Vehicle> vehicles)
        {
            List<Vehicle> cars = vehicles.Where(v => v.Type == "car").ToList();
            int totalHP = 0;
            double averageHP = 0;

            if (cars.Count > 0)
            {
                cars.ForEach(v => totalHP += v.HP);
                averageHP = (double) totalHP / cars.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageHP:f2}.");
        }

        static void PrintTrucksHP(List<Vehicle> vehicles)
        {
            List<Vehicle> trucks = vehicles.Where(v => v.Type == "truck").ToList();
            int totalHP = 0;
            double averageHP = 0;

            if (trucks.Count > 0)
            {
                trucks.ForEach(v => totalHP += v.HP);
                averageHP = (double) totalHP / trucks.Count;
            }

            Console.WriteLine($"Trucks have average horsepower of: {averageHP:f2}.");
        }
    }
}