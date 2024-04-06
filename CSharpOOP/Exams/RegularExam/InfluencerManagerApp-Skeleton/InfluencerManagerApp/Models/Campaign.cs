using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    private string brand;
    private double budget;
    private List<string> contributors;

    private Campaign()
    {
        contributors = new List<string>();
    }

    public Campaign(string brand, double budget) : this()
    {
        Brand = brand;
        Budget = budget;
    }

    public string Brand
    {
        get { return brand; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandIsrequired);
            }

            brand = value;
        }
    }

    public double Budget
    {
        get { return budget; }
        private set { budget = value; }
    }

    public IReadOnlyCollection<string> Contributors
    {
        get { return contributors.AsReadOnly(); }
    }
    
    public void Gain(double amount)
    {
        Budget += amount;
    }

    public void Engage(IInfluencer influencer)
    {
        // Might only add when influencer doesn't exist
        contributors.Add(influencer.Username);

        Budget -= influencer.CalculateCampaignPrice();
    }

    public override string ToString()
    {
        return $"{GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {contributors.Count}";
    }
}