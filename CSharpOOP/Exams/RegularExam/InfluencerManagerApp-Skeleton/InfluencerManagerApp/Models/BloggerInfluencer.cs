namespace InfluencerManagerApp.Models;

public class BloggerInfluencer : Influencer
{
    private const double ENGAGEMENT_RATE = 2.0;
    
    public BloggerInfluencer(string username, int followers) : base(username, followers, ENGAGEMENT_RATE)
    {
        // Can contribute to service campaigns
        factor_multiplier = 0.2;
    }
}