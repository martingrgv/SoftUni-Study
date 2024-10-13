using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Contracts
{
	public interface IGameService
	{
		public Task<IEnumerable<GameViewModel>> AllGames();
		public Task AddGame(GameCreateModel model, string publisherId);
		public Task EditGame(GameCreateModel model);
		public Task<GameViewModel?> GetGameById(int gameId);
		public Task<IdentityUser?> GetGamePublisher(string publisherId);
		public Task<ICollection<Genre>> GetGenres();
		public Task AddToZone(int gameId, string userId);
		public Task RemoveFromZone(int gameId, string userId);
		public Task DeleteGame(int gameId);
	}
}
