using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Services
{
	public class ShopService : IShopService
	{
		private readonly ApplicationDbContext _context;

        public ShopService(ApplicationDbContext context)
        {
			_context = context;
        }

        public async Task<IEnumerable<ProductViewModel>> AllProductsAsync()
		{
			if (_context.Products.Count() == 0)
			{
				return new List<ProductViewModel>();
			}

			return await _context.Products
				.Select(p => new ProductViewModel
				{
					Id = p.Id,
					ProductName = p.ProductName,
					Description = p.Description,
					Price = p.Price,
					ImageUrl = p.ImageUrl,
					IsSeller = false,
					HasBought = false
				})
				.ToListAsync();
		}
	}
}
