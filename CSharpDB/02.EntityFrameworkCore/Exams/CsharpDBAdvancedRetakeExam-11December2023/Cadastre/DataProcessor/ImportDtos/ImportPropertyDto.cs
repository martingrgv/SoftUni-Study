namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Common.Constants.ValidationConstants;

    [XmlType(nameof(Property))]
    public class ImportPropertyDto
    {
        [Required]
        [MinLength(PROPERTY_IDENTIFIER_MIN_LENGTH)]
        [MaxLength(PROPERTY_IDENTIFIER_MAX_LENGTH)]
        [XmlElement(nameof(PropertyIdentifier))]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(nameof(Area))]
        public int Area { get; set; }

        [MinLength(PROPERTY_DETAILS_MIN_LENGTH)]
        [MaxLength(PROPERTY_DETAILS_MAX_LENGTH)]
        [XmlElement(nameof(Details))]
        public string? Details { get; set; }

        [Required]
        [MinLength(ADDRESS_MIN_LENGTH)]
        [MaxLength(ADDRESS_MAX_LENGTH)]
        [XmlElement(nameof(Address))]
        public string Address { get; set; } = null!;

        [Required]
        [XmlElement(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
