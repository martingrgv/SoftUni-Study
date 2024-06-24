using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        { 
            get { return fuelQuantity; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel quantity cannot be negative!");
                }

                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption 
        {
            get { return fuelConsumption; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be negative or zero!");
                }

                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel tank capacity cannot be negative or zero!");
                }

                tankCapacity = value;
            }
        }

        public void Drive(double distance)
        {
            double totalConsumption = FuelConsumption * distance;
            if (totalConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= totalConsumption;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }


        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (fuelAmount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            FuelQuantity += fuelAmount;
        }
    }
}
