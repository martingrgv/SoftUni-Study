using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Core.ValidationConstants;

namespace Invoices.DataProcessor.DTOs.Import
{
    [XmlType("Client")]
    public class ClientImportDTO
    {
        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ClientNumberVatMinLength)]
        [MaxLength(ClientNumberVatMaxLength)]
        [XmlElement(nameof(NumberVat))]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public AddressImportDTO[] Addresses { get; set; } = null!;
    }

    [XmlType("Address")]
    public class AddressImportDTO
    {
        [Required]
        [MinLength(AddressStreetNameMinLength)]
        [MaxLength(AddressStreetNameMaxLength)]
        [XmlElement(nameof(StreetName))]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement(nameof(StreetNumber))]
        public int StreetNumber { get; set;}

        [Required]
        [XmlElement(nameof(PostCode))]
        public string PostCode { get; set; } = null!;

        [Required]
        [MinLength(AddressCityNameMinLength)]
        [MaxLength(AddressCityNameMaxLength)]
        [XmlElement(nameof(City))]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(AddressCountryNameMinLength)]
        [MaxLength(AddressCountryNameMaxLength)]
        [XmlElement(nameof(Country))]
        public string Country { get; set; } = null!;
    }
}
