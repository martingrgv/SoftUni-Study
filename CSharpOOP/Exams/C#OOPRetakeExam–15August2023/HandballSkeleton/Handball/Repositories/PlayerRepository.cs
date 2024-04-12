using System.Collections.Generic;
using System.Linq;
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
        IPlayer player = GetModel(name);
        return players.Remove(player);
    }

    public bool ExistsModel(string name)
    {
        IPlayer player = GetModel(name);
        
        if (player == null)
        {
            return false;
        }

        return true;
    }

    public IPlayer GetModel(string name)
    {
        return players.FirstOrDefault(p => p.Name == name);
    }
}