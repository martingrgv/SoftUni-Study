using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models;

public abstract class Diver : IDiver
{
    private string name;
    private int oxygenLevel;
    private List<string> catches;
    private double competitionPoints;
    private bool hasHealthIssues;

    public Diver(string name, int oxygenLevel)
    {
        Name = name;
        OxygenLevel = oxygenLevel;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DiversNameNull);
            }

            name = value;
        }
    }

    public int OxygenLevel
    {
        get { return oxygenLevel; }
        protected set
        {
            if (value < 0)
            {
                oxygenLevel = 0;
            }

            oxygenLevel = value;
        }
    }
    public IReadOnlyCollection<string> Catch
    {
        get { return catches.AsReadOnly(); }
    }

    public double CompetitionPoints
    {
        // Might all be rounded
        get { return Math.Round(competitionPoints, 1); }
        private set
        {
            competitionPoints = value;
        }
    }

    public bool HasHealthIssues
    {
        // Might have no need of field
        get { return hasHealthIssues; }
        private set
        {
            hasHealthIssues = value;
        }
    }
    
    public void Hit(IFish fish)
    {
        OxygenLevel -= fish.TimeToCatch;
        catches.Add(fish.Name);
        CompetitionPoints += fish.Points;
    }

    public abstract void Miss(int TimeToCatch);

    public void UpdateHealthStatus() => HasHealthIssues = HasHealthIssues == true ? false : true;

    public abstract void RenewOxy();

    public override string ToString()
    {
        return
            $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
    }
}