using System.Runtime.InteropServices;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private InfluencerRepository influencers;
    private CampaignRepository campaigns;

    public Controller()
    {
        influencers = new InfluencerRepository();
        campaigns = new CampaignRepository();
    }
    
    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        switch (typeName)
        {
            case "BusinessInfluencer":
                return AddInfluencerToRepo(new BusinessInfluencer(username, followers));
            case "FashionInfluencer":
                return AddInfluencerToRepo(new FashionInfluencer(username, followers));
            case "BloggerInfluencer":
                return AddInfluencerToRepo(new BloggerInfluencer(username, followers));
        }
        
        return $"{typeName} has not passed validation.";
    }

    private string AddInfluencerToRepo(IInfluencer influencer)
    {
        if (influencers.Models.Any(m => m.Username == influencer.Username))
        {
            throw new ArgumentException($"{influencer.Username} is already registered in {influencers.GetType().Name}.");
        }
        
        influencers.AddModel(influencer);
        return $"{influencer.Username} registered successfully to the application.";
    }

    public string BeginCampaign(string typeName, string brand)
    {
        switch (typeName)
        {
            case "ProductCampaign":
                return AddCampaignToRepo(new ProductCampaign(brand));
            case "ServiceCampaign":
                return AddCampaignToRepo(new ServiceCampaign(brand));
        }
        
        return $"{typeName} is not a valid campaign in the application.";
    }

    private string AddCampaignToRepo(ICampaign campaign)
    {
        if (campaigns.Models.Any(m => m.Brand == campaign.Brand))
        {
            throw new ArgumentException($"{campaign.Brand} campaign cannot be duplicated.");
        }
        
        campaigns.AddModel(campaign);
        return $"{campaign.Brand} started a {campaigns.GetType().Name}.";
    }

    public string AttractInfluencer(string brand, string username)
    {
        if (influencers.FindByName(username) == null)
        {
            return $"{influencers.GetType().Name} has no {username} registered in the application.";
        }
        if (campaigns.FindByName(brand) == null)
        {
            return $"There is no campaign from {brand} in the application.";
        }

        IInfluencer influencer = influencers.FindByName(username);
        ICampaign campaign = campaigns.FindByName(brand);

        if (campaign.Contributors.Any(c => c == influencer.Username))
        {
            return $"{username} is already engaged for the {brand} campaign.";
        }

        if (!InfluencerCanContribute(campaign, influencer))
        {
            return $"{username} is not eligible for the {brand} campaign.";
        }

        if (campaign.Budget <= 0 || campaign.Budget < influencer.CalculateCampaignPrice())
        {
            return $"The budget for {brand} is insufficient to engage {username}.";
        }
        
        campaign.Engage(influencer);
        influencer.EnrollCampaign(campaign.Brand);
        
        // Might not be the correct income
        influencer.EarnFee(influencer.CalculateCampaignPrice());

        return $"{username} has been successfully attracted to the {brand} campaign.";
    }

    private bool InfluencerCanContribute(ICampaign campaign, IInfluencer influencer)
    {
        switch (campaign.GetType().Name)
        {
            case "ProductCampaign":
                if (influencers is BusinessInfluencer || influencer is FashionInfluencer)
                {
                    return true;
                }
                break;
            case "ServiceCampaign":
                if (influencer is BusinessInfluencer || influencer is BloggerInfluencer)
                {
                    return true;
                }
                break;
        }

        return false;
    }

    public string FundCampaign(string brand, double amount)
    {
        if (campaigns.FindByName(brand) == null)
        {
            return "Trying to fund an invalid campaign.";
        }
        if (amount < 0)
        {
            return "Funding amount must be greater than zero.";
        }

        campaigns.FindByName(brand).Gain(amount);
        return $"{brand} campaign has been successfully funded with {amount} $";
    }

    public string CloseCampaign(string brand)
    {
        throw new NotImplementedException();
    }

    public string ConcludeAppContract(string username)
    {
        throw new NotImplementedException();
    }

    public string ApplicationReport()
    {
        throw new NotImplementedException();
    }
}