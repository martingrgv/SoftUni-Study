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

		public async Task AddProductAsync(ProductCreateModel model, string sellerId)
		{
			Product product = new Product
			{
				ProductName = model.ProductName,
				Description = model.Description,
				Price = model.Price,
				ImageUrl = model.ImageUrl,
				AddedOn = DateTime.Parse(model.AddedOn),
				CategoryId = model.CategoryId,
				SellerId = sellerId
			};

			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
		{
			if (_context.Categories.Count() == 0)
			{
				return new List<CategoryViewModel>();
			}

			return await _context.Categories
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
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
