using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cadastre.Common.Constants.ValidationConstants;

namespace Cadastre.Data.Models;

public class Property
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PROPERTY_IDENTIFIER_MAX_LENGTH)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    public int Area { get; set; }

    [MaxLength(PROPERTY_DETAILS_MAX_LENGTH)]
    public string? Details { get; set; } = null!;

    [Required]
    [MaxLength(ADDRESS_MAX_LENGTH)]
    public string Address { get; set; } = null!;

    [Required]
    public DateTime DateOfAcquisition { get; set; }

    [Required]
    public int DistrictId { get; set; }

    public IEnumerable<PropertyCitizen> PropertiesCitizens { get; set;} = new List<PropertyCitizen>();

    [ForeignKey(nameof(DistrictId))]
    public District District { get; set; } = null!;
}
