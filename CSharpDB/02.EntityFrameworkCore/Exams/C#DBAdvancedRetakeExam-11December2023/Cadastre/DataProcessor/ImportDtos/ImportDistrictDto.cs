namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Cadastre.Common.Constants.ValidationConstants;

    [XmlType(nameof(District))]
    public class ImportDistrictDto
    {
        [Required]
        [XmlElement(nameof(Name))]
        [MinLength(DISTRICT_NAME_MIN_LENGTH)]
        [MaxLength(DISTRICT_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement(nameof(PostalCode))]
        [MinLength(DISTRICT_POSTAL_CODE_MIN_LENGTH)]
        [MaxLength(DISTRICT_POSTAL_CODE_MAX_LENGTH)]
        [RegularExpression(DISTRICT_POSTAL_CODE_REGEX)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlAttribute(nameof(Region))]
        public string Region { get; set; } = null!;

        [XmlArray(nameof(Properties))]
        [XmlArrayItem(nameof(Property))]
        public ImportPropertyDto[] Properties { get; set; } = null!;
    }
}
