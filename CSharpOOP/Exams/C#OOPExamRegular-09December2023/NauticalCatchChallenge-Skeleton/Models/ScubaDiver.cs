namespace NauticalCatchChallenge.Models;

public class ScubaDiver : Diver
{
    private const int MAX_OXYGEN_LEVEL = 540;
    public ScubaDiver(string name) : base(name, MAX_OXYGEN_LEVEL)
    {
    }

    public override void Miss(int TimeToCatch)
    {
        OxygenLevel -= (int) Math.Round(TimeToCatch * 0.3, MidpointRounding.AwayFromZero);
    }

    public override void RenewOxy()
    {
        OxygenLevel = MAX_OXYGEN_LEVEL;
    }
}