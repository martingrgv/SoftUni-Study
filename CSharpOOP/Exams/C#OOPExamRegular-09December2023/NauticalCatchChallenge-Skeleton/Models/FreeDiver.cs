namespace NauticalCatchChallenge.Models;

public class FreeDiver : Diver
{
    private const int MAX_OXYGEN_LEVEL = 120;
    public FreeDiver(string name) : base(name, MAX_OXYGEN_LEVEL)
    {
    }

    public override void Miss(int TimeToCatch)
    {
        OxygenLevel -= (int) Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
    }

    public override void RenewOxy()
    {
        OxygenLevel = MAX_OXYGEN_LEVEL;
    }
}