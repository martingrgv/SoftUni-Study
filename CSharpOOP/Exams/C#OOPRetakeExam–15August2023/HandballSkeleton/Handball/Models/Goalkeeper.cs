namespace Handball.Models;

public class Goalkeeper : Player
{
    private const double INITIAL_RATING = 2.5;
    private const double RATING_INCREASE_VALUE = 0.75;
    private const double RATING_DECREASE_VALUE = 1.25;
    
    public Goalkeeper(string name) : base(name, INITIAL_RATING)
    {
    }

    public override void IncreaseRating()
    {
        Rating += RATING_INCREASE_VALUE;
    }

    public override void DecreaseRating()
    {
        Rating -= RATING_DECREASE_VALUE;
    }
}