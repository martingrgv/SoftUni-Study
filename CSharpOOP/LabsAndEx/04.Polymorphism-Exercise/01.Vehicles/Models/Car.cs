﻿namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double fuelConsumptionModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + fuelConsumptionModifier)
        {

        }
    }
}
