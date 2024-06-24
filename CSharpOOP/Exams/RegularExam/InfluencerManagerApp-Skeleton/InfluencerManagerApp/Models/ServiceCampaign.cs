namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    private const double BUDGET = 30_000;
    
    public ServiceCampaign(string brand) : base(brand, BUDGET)
    {
        // Can contribute to business and blogger influencers
    }
}