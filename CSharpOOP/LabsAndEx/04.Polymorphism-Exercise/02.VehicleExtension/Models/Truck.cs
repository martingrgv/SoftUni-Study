namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier, tankCapacity)
        {

        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
            
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
