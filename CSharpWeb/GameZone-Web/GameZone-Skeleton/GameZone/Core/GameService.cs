using AutoMapper;
using GameZone.Contracts;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Core
{
	public class GameService : IGameService
	{
		private GameZoneDbContext _context;
		private IMapper _mapper;

        public GameService(GameZoneDbContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
        }
		public async Task<IEnumerable<GameViewModel>> AllGames()
		{
			var games = await _context.Games
				.Include(g => g.Publisher)
				.ToListAsync();

			if (games.Count == 0)
			{
				return new List<GameViewModel>();
			}

			var models = _mapper.Map<IEnumerable<GameViewModel>>(games);
			return models;
		}

        public async Task AddGame(GameCreateModel model, string publisherId)
		{
			var game = _mapper.Map<Game>(model);
			game.PublisherId = publisherId;

			_context.Add(game);
			await _context.SaveChangesAsync();
		}

		public Task AddToZone(int gameId, string userId)
		{
			throw new NotImplementedException();
		}


		public Task DeleteGame(int gameId)
		{
			throw new NotImplementedException();
		}

		public Task EditGame(GameCreateModel model)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromZone(int gameId, string userId)
		{
			throw new NotImplementedException();
		}

		public Task<IdentityUser?> GetGamePublisher(string publisherId)
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<Genre>> GetGenres()
		{
			return await _context.Genres.ToListAsync();
		}
	}
}
