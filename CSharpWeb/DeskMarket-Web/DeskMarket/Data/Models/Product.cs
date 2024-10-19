using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Data.Constants.ValidationConstants;

namespace DeskMarket.Data.Models
{
	public class Product
	{
        public Product()
        {
			ProductsClients = new HashSet<ProductClient>();
        }

		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(PRODUCT_NAME_MAX_LENGTH)]
		public string ProductName { get; set; } = null!;

		[Required]
		[MaxLength(DESCRIPTION_MAX_LENGTH)]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		public string? ImageUrl { get; set; } = null!;

		[Required]
		public string SellerId { get; set; } = null!;

		[ForeignKey(nameof(SellerId))]
		public IdentityUser Seller { get; set; } = null!;

		[Required]
		public DateTime AddedOn { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; } = null!;

		public bool IsDeleted { get; set; }
		public ICollection<ProductClient> ProductsClients { get; set; }
	}
}
