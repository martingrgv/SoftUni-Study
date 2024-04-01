namespace NauticalCatchChallenge.Models;

public class DeepSeaFish : Fish
{
    private const int TIME_TO_CATHC = 180;
    
    public DeepSeaFish(string name, double points) : base(name, points, TIME_TO_CATHC)
    {
    }
}