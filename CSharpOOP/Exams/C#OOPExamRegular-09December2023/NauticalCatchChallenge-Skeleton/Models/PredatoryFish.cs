namespace NauticalCatchChallenge.Models;

public class PredatoryFish : Fish
{
    private const int TIME_TO_CATHC = 60;
    
    public PredatoryFish(string name, double points) : base(name, points, TIME_TO_CATHC)
    {
    }
}