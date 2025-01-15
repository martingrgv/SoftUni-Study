namespace DeskMarket.Models
{
	public class ProductViewModel
	{
        public int Id { get; set; }
		public string ProductName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; } = null!;
		public bool IsSeller { get; set; }
		public bool HasBought { get; set; }
	}
}
