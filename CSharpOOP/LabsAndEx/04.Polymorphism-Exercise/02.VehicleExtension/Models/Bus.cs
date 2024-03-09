namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void DriveWithPeople(double distance)
        {
            double totalConsumption = (FuelConsumption + fuelConsumptionModifier) * distance;
            if (totalConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= totalConsumption;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
    }
}
