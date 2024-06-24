using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories;

public class TeamRepository : IRepository<ITeam>
{
    private List<ITeam> teams;

    public TeamRepository()
    {
        teams = new List<ITeam>();
    }

    public IReadOnlyCollection<ITeam> Models
    {
        get { return teams.AsReadOnly(); }
    }
    
    public void AddModel(ITeam model)
    {
        teams.Add(model);
    }

    public bool RemoveModel(string name)
    {
        ITeam team = GetModel(name);
        return teams.Remove(team);
    }

    public bool ExistsModel(string name)
    {
        ITeam team = GetModel(name);

        if (team == null)
        {
            return false;
        }

        return true;
    }

    public ITeam GetModel(string name)
    {
        return teams.FirstOrDefault(t => t.Name == name);
    }
}