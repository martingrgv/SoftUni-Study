using AutoMapper;
using GameZone.Contracts;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;

namespace GameZone.Controllers
{
	public class GameController : BaseController
	{
		private IGameService _gameService;
		private IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
		{
			_gameService = gameService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allModels = await _gameService.AllGames();
			return View(allModels);
		}

		[HttpGet]
		public async Task<IActionResult> Details([FromRoute] int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var game = await _gameService.GetGameById(id);

			if (game == null)
			{
				return BadRequest();
			}

			var model = _mapper.Map<GameViewModel>(game);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> MyZone()
		{
			var model = await _gameService.GetUserZone(User.Id());

			if (model == null)
			{
				return View(new List<GameViewModel>());
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new GameCreateModel();
			model.Genres = await _gameService.GetGenres();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody]GameCreateModel model)
		{
			if (ModelState.IsValid == false)
			{
				model.Genres = await _gameService.GetGenres();
				ModelState.AddModelError("Something went wrong!", "FK THIS");

				return View(model);
			}

			await _gameService.AddGame(model, User.Id());
			return RedirectToAction(nameof(All), "Game");
		}


		[HttpGet]
		public async Task<IActionResult> Edit([FromRoute] int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			if (await _gameService.GameHasPublisher(id, User.Id()) == false)
			{
				return Unauthorized();
			}

			var game = await _gameService.GetGameById(id);
			if (game == null)
			{
				return BadRequest();
			}

			var model = _mapper.Map<GameCreateModel>(game);
			model.Genres = await _gameService.GetGenres();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromRoute]int id, [FromForm]GameCreateModel model)
		{
			if (ModelState.IsValid == false)
			{
				return View(model);
			}

			if (await _gameService.GameHasPublisher(id, User.Id()) == false)
			{
				return Unauthorized();
			}

			await _gameService.EditGame(id, model);
			return RedirectToAction(nameof(All), "Game");
		}

		[HttpGet]
		public async Task<IActionResult> AddToMyZone([FromQuery]int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			if (await _gameService.UserZonedGame(id, User.Id()))
			{
				return RedirectToAction(nameof(MyZone), "Game");
			}

			await _gameService.AddToZone(id, User.Id());
			return RedirectToAction(nameof(MyZone), "Game");
		}

		public async Task<IActionResult> StrikeOut([FromQuery] int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			await _gameService.StrikeOutGame(id, User.Id());
			return RedirectToAction(nameof(MyZone), "Game");
		}

		[HttpGet]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			if (await _gameService.GameHasPublisher(id, User.Id()) == false)
			{
				return Unauthorized();
			}

			var game = await _gameService.GetGameById(id);
			if (game == null)
			{
				return BadRequest();
			}

			var model = _mapper.Map<GameViewModel>(game);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			if (await _gameService.GameHasPublisher(id, User.Id()) == false)
			{
				return Unauthorized();
			}

			await _gameService.DeleteGame(id);
			return RedirectToAction(nameof(All), "Game");
		}
	}
}
