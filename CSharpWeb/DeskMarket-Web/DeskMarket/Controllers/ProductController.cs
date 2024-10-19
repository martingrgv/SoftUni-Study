using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using System.Security.Claims;

namespace DeskMarket.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IShopService _shopService;

        public ProductController(IShopService shopService)
        {
			_shopService = shopService;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var model = await _shopService.GetAllProductsAsync(User.Id()!);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details([FromRoute] int id)
		{
			var model = await _shopService.GetProductDetails(id);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new ProductCreateModel();
			model.Categories = await _shopService.GetAllCategoriesAsync();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] ProductCreateModel model)
		{
			if (ModelState.IsValid == false)
			{
				model.Categories = await _shopService.GetAllCategoriesAsync();
				return View(model);
			}

			await _shopService.AddProductAsync(model, User.Id()!);
			return RedirectToAction(nameof(Index), "Product");
		}
	}
}
