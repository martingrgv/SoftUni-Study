using GameZone.Contracts;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;

namespace GameZone.Controllers
{
	public class GameController : BaseController
	{
		private IGameService _gameService;

		public GameController(IGameService gameService)
		{
			_gameService = gameService;
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

			var model = await _gameService.GetGameViewModelById(id);

			if (model == null)
			{
				return BadRequest();
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult MyZone()
		{
			return View();
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
		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult AddToMyZone()
		{
			return View();
		}

		public IActionResult StrikeOut()
		{
			return View();
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

			var model = await _gameService.GetGameViewModelById(id);
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
