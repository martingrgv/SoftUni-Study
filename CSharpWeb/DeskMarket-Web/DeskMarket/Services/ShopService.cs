﻿using DeskMarket.Data;
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

		public async Task AddToCartAsync(int productId, string userId)
		{
			_context.ProductsClients.Add(new ProductClient
			{
				ProductId = productId,
				ClientId = userId
			});
			await _context.SaveChangesAsync();
		}

		public async Task EditProductAsync(int productId, ProductCreateModel model)
		{
			var product = await GetProductByIdAsync(productId);

			if (product == null)
			{
				throw new InvalidOperationException($"Could not find product with Id {productId}");
			}

			product.ProductName = model.ProductName;
			product.Description = model.Description;
			product.Price = model.Price;
			product.AddedOn = DateTime.Parse(model.AddedOn);
			product.ImageUrl = model.ImageUrl;
			product.CategoryId = model.CategoryId;
			product.SellerId = model.SellerId!;

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
				.Where(p => p.IsDeleted == false)
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

		public async Task<IEnumerable<ProductViewModel>> GetCartProductsAsync(string userId)
		{
			return await _context.ProductsClients
				.Include(pc => pc.Product)
				.Include(pc => pc.Client)
				.Where(pc => pc.ClientId == userId)
				.Select(pc => new ProductViewModel
				{
					Id = pc.ProductId,
					ProductName = pc.Product.ProductName,
					Description = pc.Product.Description,
					Price = pc.Product.Price,
					ImageUrl = pc.Product.ImageUrl,
					IsSeller = pc.Product.SellerId == userId,
					HasBought = pc.Product.IsDeleted
				})
				.ToListAsync();
		}

		public async Task<Product?> GetProductByIdAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);

			if (product == null)
			{
				return null;
			}

			await _context.Entry(product)
				.Reference(p => p.Category)
				.LoadAsync();
			await _context.Entry(product)
				.Reference(p => p.Seller)
				.LoadAsync();

			return product;
		}

		public async Task RemoveAsync(int productId)
		{
			var product = await GetProductByIdAsync(productId);

			if (product == null)
			{
				throw new InvalidOperationException($"Could not find product with Id {productId}");
			}

			product.IsDeleted = true;
			await _context.SaveChangesAsync();
		}

		public async Task RemoveFromCartAsync(int productId, string userId)
		{
			var productClient = await _context.ProductsClients.FindAsync(productId, userId);
			if (productClient == null)
			{
				return;
			}

			_context.Remove(productClient);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> UserHasProductAsync(int productId, string userId)
		{
			return await _context.ProductsClients
				.AnyAsync(pc => pc.ProductId == productId && pc.ClientId == userId);
		}
	}
}
