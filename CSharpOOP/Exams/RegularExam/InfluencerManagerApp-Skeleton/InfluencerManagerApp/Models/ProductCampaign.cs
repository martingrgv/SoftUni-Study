namespace InfluencerManagerApp.Models;

public class ProductCampaign : Campaign
{
    private const double BUDGET = 60_000;
    
    public ProductCampaign(string brand) : base(brand, BUDGET)
    {
        // Can contribute to business and fashion influencers
    }
}