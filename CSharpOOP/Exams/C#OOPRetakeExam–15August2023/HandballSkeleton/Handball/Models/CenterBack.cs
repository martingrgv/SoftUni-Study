namespace Handball.Models;

public class CenterBack : Player
{
    private const double INITIAL_RATING = 4;
    private const double RATING_INCREASE_VALUE = 1;
    private const double RATING_DECREASE_VALUE = 1;
    
    public CenterBack(string name) : base(name, INITIAL_RATING)
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