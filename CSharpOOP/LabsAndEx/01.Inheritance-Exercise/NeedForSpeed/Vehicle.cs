namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int hp, double fuel)
        {
            HP = hp;
            Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }

        public int HP { get; set; }
        public double Fuel { get; set; }
        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual void Drive (double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
