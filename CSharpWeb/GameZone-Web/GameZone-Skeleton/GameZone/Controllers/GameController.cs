using GameZone.Contracts;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
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
		public IActionResult Details()
		{
			return View();
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
		public async Task<IActionResult> Add(GameCreateModel model)
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

		public IActionResult Delete()
		{
			return View();
		}
	}
}
