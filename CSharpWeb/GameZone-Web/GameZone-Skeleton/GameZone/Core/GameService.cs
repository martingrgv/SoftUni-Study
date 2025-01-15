using AutoMapper;
using GameZone.Contracts;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

		public Task<bool> UserZonedGame(int gameId, string userId)
		{
			if (_context.GamersGames.Find(gameId, userId) == null)
			{
				return Task.FromResult(false);
			}

			return Task.FromResult(true);
		}

		public async Task AddToZone(int gameId, string userId)
		{
			_context.Add(new GamerGame
			{
				GameId = gameId,
				GamerId = userId
			});

			await _context.SaveChangesAsync();
		}


		public async Task DeleteGame(int gameId)
		{
			var game = _context.Games.Find(gameId);

			if (game == null)
			{
				return;
			}

			_context.Games.Remove(game);
			await _context.SaveChangesAsync();
		}

		public async Task EditGame(int gameId, GameCreateModel model)
		{
			var game = _context.Games.Find(gameId);

			if (game == null)
			{
				throw new InvalidOperationException("Game not found!");
			}

			_mapper.Map(model, game);
			await _context.SaveChangesAsync();
		}	

		public Task RemoveFromZone(int gameId, string userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GameHasPublisher(int gameId, string publisherId)
		{
			var game = _context.Games.Find(gameId);
			
			if (game == null)
			{
				throw new InvalidOperationException("Game not found!");
			}

			if (game.PublisherId != publisherId)
			{
				return Task.FromResult(false);
			}

			return Task.FromResult(true);
		}

		public async Task<ICollection<Genre>> GetGenres()
		{
			return await _context.Genres.ToListAsync();
		}

		public Task<Game?> GetGameById(int gameId)
		{
			var game = _context.Games
				.Find(gameId);

			if (game == null)
			{
				return Task.FromResult((Game?)null);
			}

			_context.Entry(game)
				.Reference(g => g.Genre)
				.Load();
			_context.Entry(game)
				.Reference(g => g.Publisher)
				.Load();

			return Task.FromResult((Game?)game);
		}

		public async Task<IEnumerable<GameViewModel?>> GetUserZone(string userId)
		{
			var gamersGames = await _context.GamersGames
				.Where(gg => gg.GamerId == userId)
				.Include(gg => gg.Game)
				.ToListAsync();

			var games = _mapper.Map<IEnumerable<GameViewModel?>>(gamersGames
				.Select(gg => gg.Game)
				.ToList());

			if (games.Count() == 0)
			{
				return null!;
			}

			return games;
		}

		public async Task StrikeOutGame(int id, string userId)
		{
			var gamerGame = await _context.GamersGames.FindAsync(id, userId);

			if (gamerGame == null)
			{
				return;
			}

			_context.Remove(gamerGame);
			await _context.SaveChangesAsync();
		}
	}
}
