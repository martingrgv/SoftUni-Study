using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Contracts
{
	public interface IGameService
	{
		Task<IEnumerable<GameViewModel>> AllGames();
		Task AddGame(GameCreateModel model, string publisherId);
		Task EditGame(int gameId, GameCreateModel model);
		Task<bool> GameHasPublisher(int gameId, string publisherId);
		Task<ICollection<Genre>> GetGenres();
		Task AddToZone(int gameId, string userId);
		Task RemoveFromZone(int gameId, string userId);
		Task DeleteGame(int gameId);
		Task<Game?> GetGameById(int gameId);
		Task<bool> UserZonedGame(int gameId, string userId);
		Task<IEnumerable<GameViewModel?>> GetUserZone(string userId);
		Task StrikeOutGame(int id, string userId);
	}
}
