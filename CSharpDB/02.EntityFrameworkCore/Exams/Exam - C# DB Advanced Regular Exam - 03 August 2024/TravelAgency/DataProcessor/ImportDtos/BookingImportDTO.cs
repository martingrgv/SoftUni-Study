using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static TravelAgency.Core.ValidationConstants;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class BookingImportDTO
    {
        [Required]
        [JsonProperty(nameof(BookingDate))]
        public string BookingDate { get; set; } = null!;

        [Required]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        [JsonProperty(nameof(CustomerName))]
        public string CustomerName { get; set; } = null!;

        [Required]
        [MinLength(TourPackageNameMinLength)]
        [MaxLength(TourPackageNameMaxLength)]
        [JsonProperty(nameof(TourPackageName))]
        public string TourPackageName { get; set; } = null!;
    }
}
