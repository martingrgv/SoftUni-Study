namespace InfluencerManagerApp.Models;

public class BusinessInfluencer : Influencer
{
    private const double ENGAGEMENT_RATE = 3.0;
    
    public BusinessInfluencer(string username, int followers) : base(username, followers, ENGAGEMENT_RATE)
    {
        // Can contribute to all campaigns
        factor_multiplier = 0.15;
    }
}