using Invoices.Data.Enumerations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Invoices.Core.ValidationConstants;

namespace Invoices.DataProcessor.DTOs.Import
{
    public class ProductImportDTO
    {
        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ProductPriceMinLength, ProductPriceMaxLength)]
        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(CategoryType))]
        [JsonProperty(nameof(CategoryType))]
        public CategoryType CategoryType { get; set; }

        [Required]
        [JsonProperty("Clients")]
        public int[] ClientsIds { get; set; } = null!;
    }
}
