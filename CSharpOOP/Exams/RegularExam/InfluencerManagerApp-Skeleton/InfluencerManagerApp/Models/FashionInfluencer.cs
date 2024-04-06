namespace InfluencerManagerApp.Models;

public class FashionInfluencer : Influencer
{
    private const double ENGAGEMENT_RATE = 4.0;
    
    public FashionInfluencer(string username, int followers) : base(username, followers, ENGAGEMENT_RATE)
    {
        // Can contribute to product campaigns
        factor_multiplier = 0.1;
    }
}