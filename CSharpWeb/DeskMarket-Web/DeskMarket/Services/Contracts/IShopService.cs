using DeskMarket.Models;

namespace DeskMarket.Services.Contracts
{
	public interface IShopService
	{
		Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
		Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
		Task AddProductAsync(ProductCreateModel model, string sellerId);
	}
}
