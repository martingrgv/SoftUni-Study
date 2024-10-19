using DeskMarket.Models;

namespace DeskMarket.Services.Contracts
{
	public interface IShopService
	{
		Task<IEnumerable<ProductViewModel>> AllProductsAsync(); 
	}
}
