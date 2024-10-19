using System.Security.Policy;

namespace DeskMarket.Models
{
	public class ProductDetailViewModel
	{
        public int Id { get; set; }
		public string ProductName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; } = null!;
		public bool HasBought { get; set; }
		public string CategoryName { get; set; } = null!;
		public string AddedOn { get; set; } = null!;
		public string Seller { get; set; } = null!;
	}
}
