namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int hp, double fuel) : base(hp, fuel)
        {
            DefaultFuelConsumption = 10;
        }

        public new double DefaultFuelConsumption { get; set; }

        public override void Drive (double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
