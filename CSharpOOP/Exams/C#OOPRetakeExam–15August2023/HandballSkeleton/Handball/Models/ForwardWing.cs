namespace Handball.Models;

public class ForwardWing : Player
{
    private const double INITIAL_RATING = 5.5;
    private const double RATING_INCREASE_VALUE = 1.25;
    private const double RATING_DECREASE_VALUE = 0.75;
    
    public ForwardWing(string name) : base(name, INITIAL_RATING)
    {
    }

    public override void IncreaseRating()
    {
        Rating += RATING_INCREASE_VALUE;
        
        if (Rating > MAX_RATING)
        {
            Rating = MAX_RATING;
        }
    }

    public override void DecreaseRating()
    {
        Rating -= RATING_DECREASE_VALUE;
        
        if (Rating < MIN_RATING)
        {
            Rating = MIN_RATING;
        }
    }
}