using System.Collections.Generic;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories;

public class PlayerRepository : IRepository<IPlayer>
{
    private List<IPlayer> players;

    public PlayerRepository()
    {
        players = new List<IPlayer>();
    }

    public IReadOnlyCollection<IPlayer> Models
    {
        get { return players.AsReadOnly(); }
    }
    
    public void AddModel(IPlayer model)
    {
        players.Add(model);
    }

    public bool RemoveModel(string name)
    {
        return players.Remove(p => p.Name == name);
    }

    public bool ExistsModel(string name)
    {
        throw new System.NotImplementedException();
    }

    public IPlayer GetModel(string name)
    {
        throw new System.NotImplementedException();
    }
}