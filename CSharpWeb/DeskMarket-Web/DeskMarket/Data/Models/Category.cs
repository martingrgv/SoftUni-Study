using System.ComponentModel.DataAnnotations;
using static DeskMarket.Data.Constants.ValidationConstants;

namespace DeskMarket.Data.Models
{
	public class Category
	{
        public Category()
        {
			Products = new HashSet<Product>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(CATEGORY_NAME_MAX_LENGTH)]
		public string Name { get; set; } = null!;

		public ICollection<Product> Products { get; set; } 
	}
}
