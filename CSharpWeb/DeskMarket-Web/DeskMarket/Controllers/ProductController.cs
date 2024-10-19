using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;

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
			var model = await _shopService.AllProductsAsync();
			return View(model);
		}
	}
}
