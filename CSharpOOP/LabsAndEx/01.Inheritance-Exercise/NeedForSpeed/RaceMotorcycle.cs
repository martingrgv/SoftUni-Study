namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int hp, double fuel) : base(hp, fuel)
        {
            DefaultFuelConsumption = 8;
        }

        public new double DefaultFuelConsumption { get; set; }

        public override void Drive (double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
