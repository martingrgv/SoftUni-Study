using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TravelAgency.Core.ValidationConstants;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TourPackageNameMaxLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(TourPackageDescriptionMaxLength)]
        public string? Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new List<TourPackageGuide>();
    }
}
