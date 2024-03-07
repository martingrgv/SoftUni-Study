namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier)
        {

        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
