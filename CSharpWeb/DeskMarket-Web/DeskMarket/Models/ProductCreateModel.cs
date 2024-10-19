using System.ComponentModel.DataAnnotations;
using static DeskMarket.Data.Constants.ValidationConstants;

namespace DeskMarket.Models
{
	public class ProductCreateModel
	{
        public ProductCreateModel()
        {
			Categories = new HashSet<CategoryViewModel>();
        }

		[Required]
		[Display(Name = "Name")]
		[StringLength(PRODUCT_NAME_MAX_LENGTH, MinimumLength = PRODUCT_NAME_MIN_LENGTH, ErrorMessage = "Product name must be between {2} and {1} characters long!")]
        public string ProductName { get; set; } = null!;

		[Required]
		[Display(Name = "Description")]
		[StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH, ErrorMessage = "Description must be between {2} and {1} characters long!")]
		public string Description { get; set; } = null!;

		[Required]
		[Display(Name = "Price")]
		[Range((double)PRICE_MIN_LENGTH, (double)PRICE_MAX_LENGTH, ErrorMessage = "Product price must be between {1} and {2}!")]
		public decimal Price { get; set; }

		[Display(Name = "Image URL")]
		public string? ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Added on")]
		public string AddedOn { get; set; } = null!;

		[Required]
		public int CategoryId { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }
	}
}
