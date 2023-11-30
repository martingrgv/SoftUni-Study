public class Car
{
    public string Name { get; set; }
    public int Mileage { get; set; }
    public int Fuel { get; set; }

    public Car(string name, int mileage, int fuel)
    {
        Name = name;
        Mileage = mileage;
        Fuel = fuel;
    }

    public void Drive(int travelDistance, int fuelConsumption)
    {
        if (fuelConsumption > Fuel)
        {
            System.Console.WriteLine("Not enough fuel to make that ride");
            return;
        }

        Fuel -= fuelConsumption;
        Mileage += travelDistance;

        System.Console.WriteLine($"{Name} driven for {travelDistance} kilometers. {fuelConsumption} liters of fuel consumed.");
    }

    public void Refuel(int refuelAmount)
    {
        Fuel += refuelAmount;

        if (Fuel > 75)
        {
            refuelAmount = refuelAmount - (Fuel - 75);
            Fuel = 75;
        }

        System.Console.WriteLine($"{Name} refueled with {refuelAmount} liters");
    }

    public void Revert(int kilometers)
    {
        Mileage -= kilometers;

        if (Mileage < 10000)
        {
            Mileage = 10000;
            return;
        }

        System.Console.WriteLine($"{Name} mileage decreased by {kilometers} kilometers");
    }
}