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
			var product = await _shopService.GetProductByIdAsync(id);

			if (product == null)
			{
				return BadRequest();
			}

			var model = new ProductDetailViewModel
			{
				Id = product.Id,
				ProductName = product.ProductName,
				Description = product.Description,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				HasBought = product.IsDeleted,
				CategoryName = product.Category.Name,
				AddedOn = product.AddedOn.ToString("dd-MM-yyyy"),
				Seller = product.Seller.UserName!
			};
;
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
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit([FromRoute] int id)
		{
			var product = await _shopService.GetProductByIdAsync(id);

			if (product == null)
			{
				return BadRequest();
			}
			if (product.SellerId != User.Id())
			{
				return Unauthorized();
			}

			var model = new ProductCreateModel
			{
				ProductName = product.ProductName,
				Description = product.Description,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				AddedOn = product.AddedOn.ToString("dd-MM-yyyy"),
				CategoryId = product.CategoryId,
				SellerId = product.SellerId
			};
			model.Categories = await _shopService.GetAllCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromRoute]int id, [FromForm] ProductCreateModel model)
		{
			if (model.SellerId != User.Id())
			{
				return Unauthorized();
			}
			if (ModelState.IsValid == false)
			{
				model.Categories = await _shopService.GetAllCategoriesAsync();
				return View(model);
			}

			await _shopService.EditProductAsync(id, model);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete([FromRoute] int id, [FromForm]ProductDeleteModel? model)
		{
			var product = await _shopService.GetProductByIdAsync(id);

			if (product == null)
			{
				return BadRequest();
			}
			if (product.SellerId != User.Id())
			{
				return Unauthorized();
			}

			if (model.Id != 0)
			{
				await _shopService.RemoveAsync(id);
				return RedirectToAction(nameof(Index));
			}

			model = new ProductDeleteModel
			{
				Id = product.Id,
				ProductName = product.ProductName,
				SellerId = product.SellerId,
				Seller = product.Seller.UserName!
			};

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Cart()
		{
			var model = await _shopService.GetCartProductsAsync(User.Id()!);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int id)
		{
			await _shopService.AddToCartAsync(id, User.Id()!);
			return RedirectToAction(nameof(Cart));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(int id)
		{
			if (await _shopService.UserHasProductAsync(id, User.Id()!))
			{
				await _shopService.RemoveFromCartAsync(id, User.Id()!);
			}

			return RedirectToAction(nameof(Cart));
		}
	}
}
