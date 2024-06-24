namespace NauticalCatchChallenge.Models;

public class ReefFish : Fish
{
    private const int TIME_TO_CATCH = 30;
    
    public ReefFish(string name, double points) : base(name, points, TIME_TO_CATCH)
    {
    }
}