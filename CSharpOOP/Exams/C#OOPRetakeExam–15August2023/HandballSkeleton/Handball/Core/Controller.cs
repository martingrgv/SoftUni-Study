using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;

namespace Handball.Core;

public class Controller : IController
{
    private PlayerRepository players;
    private TeamRepository teams;
    
    public Controller()
    {
        players = new PlayerRepository();
        teams = new TeamRepository();
    }
        
    public string NewTeam(string name)
    {
        if (teams.ExistsModel(name))
        {
            return $"{name} is already added to the {teams.GetType().Name}.";
        }

        ITeam team = new Team(name);
        teams.AddModel(team);
        
        return $"{name} is successfully added to the {teams.GetType().Name}.";
    }

    private string AddPlayer(IPlayer player)
    {
        if (players.ExistsModel(player.Name))
        {
            player = players.GetModel(player.Name);
            return $"{player.Name} is already added to the {players.GetType().Name} as {player.GetType().Name}.";
        }
        
        players.AddModel(player);
        return $"{player.Name} is filed for the handball league.";
    }

    public string NewPlayer(string typeName, string name)
    {
        // Might want to print invalid position with added name
        if (typeName == "Goalkeeper") return AddPlayer(new Goalkeeper(name));
        if (typeName == "CenterBack") return AddPlayer(new CenterBack(name));
        if (typeName == "ForwardWing") return AddPlayer(new ForwardWing(name));
        
        return $"{typeName} is invalid position for the application.";
    }

    public string NewContract(string playerName, string teamName)
    {
        if (!players.ExistsModel(playerName))
        {
            return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
        }
        if (!teams.ExistsModel(teamName))
        {
            return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";
        }

        IPlayer player = players.GetModel(playerName);

        if (player.Team != null)
        {
            return $"Player {playerName} has already signed with {player.Team}.";
        }

        player.JoinTeam(teamName);
        teams.GetModel(teamName).SignContract(player);
        
        return $"Player {playerName} signed a contract with {teamName}.";
    }

    public string NewGame(string firstTeamName, string secondTeamName)
    {
        ITeam team1 = teams.GetModel(firstTeamName);
        ITeam team2 = teams.GetModel(secondTeamName);

        if (team1.OverallRating > team2.OverallRating)
        {
            team1.Win();
            team2.Lose();
            return $"Team {team1.Name} wins the game over {team2.Name}!";
        }
        else if (team1.OverallRating < team2.OverallRating)
        {
            team1.Lose();
            team2.Win();
            return $"Team {team2.Name} wins the game over {team1.Name}!";
        }
        else
        {
            team1.Draw();
            team2.Draw();
            return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
        }
    }

    public string PlayerStatistics(string teamName)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"***{teamName}***");
        
        ITeam team = teams.GetModel(teamName);
        List<IPlayer> orderedPlayers = team.Players.OrderByDescending(p => p.Rating)
            .ThenBy(p => p.Name)
            .ToList();
        
        // Possible 0 players
        foreach (var player in orderedPlayers)
        {
            sb.AppendLine(player.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public string LeagueStandings()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"***League Standings***");
        
        List<ITeam> orderedTeams = teams.Models.OrderByDescending(t => t.PointsEarned)
            .ThenByDescending(t => t.OverallRating)
            .ThenBy(t => t.Name)
            .ToList();

        foreach (var team in orderedTeams)
        {
            sb.AppendLine(team.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}