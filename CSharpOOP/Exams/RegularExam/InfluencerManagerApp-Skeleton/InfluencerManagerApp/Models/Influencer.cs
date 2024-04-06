using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    private string username;
    private int followers;
    private double engagementRate;
    private double income;
    private List<string> participations;
    protected double factor_multiplier;

    private Influencer()
    {
        Income = 0;
        participations = new List<string>();
    }

    public Influencer(string username, int followers, double engagementRate) : this()
    {
        Username = username;
        Followers = followers;
        EngagementRate = engagementRate;
    }

    public string Username
    {
        get { return username; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }

            username = value;
        }
    }

    public int Followers
    {
        get { return followers; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }

            followers = value;
        }
    }

    public double EngagementRate
    {
        get { return engagementRate; }
        private set { engagementRate = value; }
    }

    public double Income
    {
        get { return income; }
        private set { income = value; }
    }
    public IReadOnlyCollection<string> Participations
    {
        get { return participations.AsReadOnly(); }
    }
    
    public void EarnFee(double amount)
    {
        Income += amount;
    }

    public void EnrollCampaign(string brand)
    {
        // Might need to not have the if statement
        if (!participations.Contains(brand))
        {
            participations.Add(brand);
        }
    }

    public void EndParticipation(string brand)
    {
        if (participations.Contains(brand))
        {
            participations.Remove(brand);
        }
    }

    public int CalculateCampaignPrice()
    {
        return (int) Math.Floor(Followers * EngagementRate * factor_multiplier);
    }

    public override string ToString()
    {
        return $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }
}