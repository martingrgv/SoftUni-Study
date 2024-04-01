namespace NauticalCatchChallenge.Models;

public class FreeDiver : Diver
{
    private const int OXYGEN_LEVEL = 120;
    public FreeDiver(string name) : base(name, OXYGEN_LEVEL)
    {
    }

    public override void Miss(int TimeToCatch)
    {
        OxygenLevel -= (int) Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        
    }

    public override void RenewOxy()
    {
        throw new NotImplementedException();
    }
}