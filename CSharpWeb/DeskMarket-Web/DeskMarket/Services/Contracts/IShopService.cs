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
	}
}
