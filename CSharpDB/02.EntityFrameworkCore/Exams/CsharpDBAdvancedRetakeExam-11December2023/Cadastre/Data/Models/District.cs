using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;
using static Cadastre.Constants.ValidationConstants;

namespace Cadastre.Data.Models;

public class District
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DISTRICT_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(DISTRICT_POSTAL_CODE_MAX_LENGTH)]
    public string PostalCode { get; set;} = null!;

    [Required]
    public Region Region { get; set; }

    public IEnumerable<Property> Properties { get; set; } = new List<Property>();
}
