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

		public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(string userId)
		{
			if (_context.Products.Count() == 0)
			{
				return new List<ProductViewModel>();
			}

			return await _context.Products
				.Include(p => p.Seller)
				.Select(p => new ProductViewModel
				{
					Id = p.Id,
					ProductName = p.ProductName,
					Description = p.Description,
					Price = p.Price,
					ImageUrl = p.ImageUrl,
					IsSeller = p.SellerId == userId,
					HasBought = p.IsDeleted
				})
				.ToListAsync();
		}

		public async Task<ProductDetailViewModel> GetProductDetails(int productId)
		{
			var product = await _context.Products.FindAsync(productId);

			if (product == null)
			{
				throw new InvalidOperationException($"Could not find product with id {productId}!");
			}

			await _context.Entry(product)
				.Reference(p => p.Category)
				.LoadAsync();
			await _context.Entry(product)
				.Reference(p => p.Seller)
				.LoadAsync();

			return new ProductDetailViewModel
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
		}
	}
}
