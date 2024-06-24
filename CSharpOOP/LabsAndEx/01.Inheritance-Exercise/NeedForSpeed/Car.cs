namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int hp, double fuel) : base(hp, fuel)
        {
            DefaultFuelConsumption = 3;   
        }
        public new double DefaultFuelConsumption { get; set; }

        public override void Drive (double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
