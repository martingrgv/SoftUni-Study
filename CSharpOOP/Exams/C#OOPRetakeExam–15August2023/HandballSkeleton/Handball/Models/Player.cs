using System;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models;

public abstract class Player : IPlayer
{
    private string name;
    private double rating;
    private string team;

    protected const double MAX_RATING = 10;
    protected const double MIN_RATING = 1;

    public Player(string name, double rating)
    {
        Name = name;
        Rating = rating;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.PlayerNameNull);
            }

            name = value;
        }
    }

    public double Rating
    {
        get { return rating; }
        protected set
        {
            rating = value;
        }
    }

    public string Team
    {
        get { return team; }
        private set { team = value; }
    }
    
    public void JoinTeam(string name)
    {
        Team = name;
    }

    public abstract void IncreaseRating();

    public abstract void DecreaseRating();

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}"
               + Environment.NewLine +
               $"--Rating: {Rating}";
    }
}