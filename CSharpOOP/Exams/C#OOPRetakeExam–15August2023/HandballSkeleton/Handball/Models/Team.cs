using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models;

public class Team : ITeam
{
    private const int WINRATE_INCREASE_VALUE = 3;
    private const int DRAWRATE_INCREASE_VALUE = 1;
        
    private string name;
    private int pointsEarned;
    private double overallRating;
    private List<IPlayer> players;

    public Team(string name) : base()
    {
        players = new List<IPlayer>();
        Name = name;
        PointsEarned = 0;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }

            name = value;
        }
    }

    public int PointsEarned
    {
        get { return pointsEarned; }
        private set
        {
            pointsEarned = value;
        }
    }

    public double OverallRating
    {
        get
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return players.Average(p => p.Rating);
        }
    }

    public IReadOnlyCollection<IPlayer> Players
    {
        get { return players.AsReadOnly(); }
    }
    
    public void SignContract(IPlayer player)
    {
        players.Add(player);
    }

    public void Win()
    {
        pointsEarned += WINRATE_INCREASE_VALUE;
        players.ForEach(p => p.IncreaseRating());
    }

    public void Lose()
    {
        players.ForEach(p => p.DecreaseRating());
    }

    public void Draw()
    {
        pointsEarned += DRAWRATE_INCREASE_VALUE;
        var goalkeepers = players.Where(p => p.GetType() == typeof(Goalkeeper));

        foreach (var player in goalkeepers)
        {
            player.IncreaseRating();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
        sb.AppendLine($"--Overall rating: {OverallRating}");
        sb.Append($"--Players: ");
        
        if (players.Count > 0)
        {
            for (int i = 0; i < players.Count - 1; i++)
            {
                sb.Append($"{players[i].Name}, ");
            }
            
            sb.Append($"{players[players.Count - 1].Name}");
        }
        else
        {
            sb.Append("none");
                
        }

        return sb.ToString().TrimEnd();
    }
}