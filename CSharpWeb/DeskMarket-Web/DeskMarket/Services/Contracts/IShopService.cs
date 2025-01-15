using DeskMarket.Data.Models;
using DeskMarket.Models;

namespace DeskMarket.Services.Contracts
{
	public interface IShopService
	{
		Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(string userId);
		Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
		Task AddProductAsync(ProductCreateModel model, string sellerId);
		Task<Product?> GetProductByIdAsync(int productId);
		Task EditProductAsync(int productId, ProductCreateModel model);
		Task RemoveAsync(int productId);
		Task AddToCartAsync(int productId, string userId);
		Task RemoveFromCartAsync(int productId, string userId);
		Task<bool> UserHasProductAsync(int productId, string userId);
		Task<IEnumerable<ProductViewModel>> GetCartProductsAsync(string userId);
	}
}
