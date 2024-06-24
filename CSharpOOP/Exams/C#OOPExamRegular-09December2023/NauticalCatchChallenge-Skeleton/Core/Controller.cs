using System.Text;
using System.Xml.Schema;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    private DiverRepository divers;
    private FishRepository fishes;
    
    public Controller()
    {
        divers = new DiverRepository();
        fishes = new FishRepository();
    }
    
    public string DiveIntoCompetition(string diverType, string diverName)
    {
        switch (diverType)
        {
            case "FreeDiver":
                return AddDiver(new FreeDiver(diverName));
            case "ScubaDiver":
                return AddDiver(new ScubaDiver(diverName));
        }
        
        return $"{diverType} is not allowed in our competition.";
    }

    private string AddDiver(IDiver diver)
    {
        if (divers.Models.Any(d => d.Name == diver.Name))
        {
            return $"{diver.Name} is already a participant -> {divers.GetType().Name}.";
        }

        divers.AddModel(diver);
        return $"{diver.Name} is successfully registered for the competition -> {divers.GetType().Name}.";
    }

    public string SwimIntoCompetition(string fishType, string fishName, double points)
    {
        switch (fishType)
        {
            case "ReefFish":
                return AddFish(new ReefFish(fishName, points));
            case "DeepSeaFish":
                return AddFish(new DeepSeaFish(fishName, points));
            case "PredatoryFish":
                return AddFish(new PredatoryFish(fishName, points));
        }
        
        return $"{fishType} is forbidden for chasing in our competition.";
    }
    
    private string AddFish(IFish fish)
    {
        if (fishes.Models.Any(f => f.Name == fish.Name))
        {
            return $"{fish.Name} is already allowed -> {fish.GetType().Name}.";
        }

        fishes.AddModel(fish);
        return $"{fish.Name} is allowed for chasing.";
    }

    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {
        if (!divers.Models.Any(d => d.Name == diverName))
        {
            return $"{divers.GetType().Name} has no {diverName} registered for the competition.";
        }
        if (!fishes.Models.Any(f => f.Name == fishName))
        {
            return $"{fishName} is not allowed to be caught in this competition.";
        }

        IDiver diver = divers.GetModel(diverName);

        if (diver.HasHealthIssues)
        {
            return $"{diverName} will not be allowed to dive, due to health issues.";
        }

        IFish fish = fishes.GetModel(fishName);

        if (fish.TimeToCatch > diver.OxygenLevel)
        {
            diver.Miss(fish.TimeToCatch);
            CheckHealth(diver);
            return $"{diverName} missed a good {fishName}.";
        }

        if (fish.TimeToCatch == diver.OxygenLevel)
        {
            if (isLucky)
            {
                diver.Hit(fish);
                return $"{diverName} hits a {fish.Points}pt. {fishName}.";
            }
            
            diver.Miss(fish.TimeToCatch);
            CheckHealth(diver);
            return $"{diverName} missed a good {fishName}.";
        }
        
        diver.Hit(fish);
        return $"{diverName} hits a {fish.Points}pt. {fishName}.";
    }

    private void CheckHealth(IDiver diver)
    {
        if (diver.OxygenLevel <= 0 && !diver.HasHealthIssues)
        {
            diver.UpdateHealthStatus();
        }
    }

    public string HealthRecovery()
    {
        List<IDiver> unhealthyDivers = divers.Models.Where(d => d.HasHealthIssues).ToList();

        foreach (var diver in unhealthyDivers)
        {
            diver.UpdateHealthStatus();
            diver.RenewOxy();
        }

        return $"Divers recovered: {unhealthyDivers.Count}";
    }

    public string DiverCatchReport(string diverName)
    {
        IDiver diver = divers.GetModel(diverName);

        if (diver == null)
        {
            throw new InvalidOperationException("Diver cannot be found");
        }
            
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(diver.ToString());
        sb.AppendLine("Catch Report:");

        foreach (var fish in diver.Catch)
        {
            sb.AppendLine(fish);
        }

        return sb.ToString().TrimEnd();
    }

    public string CompetitionStatistics()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine("**Nautical-Catch-Challenge**");

        foreach (var diver in divers.Models)
        {
            sb.AppendLine(diver.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}