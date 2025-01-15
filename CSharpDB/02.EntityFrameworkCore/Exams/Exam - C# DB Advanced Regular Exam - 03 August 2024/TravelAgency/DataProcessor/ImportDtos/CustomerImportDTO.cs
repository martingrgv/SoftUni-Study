using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static TravelAgency.Core.ValidationConstants;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class CustomerImportDTO
    {
        [Required]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        [XmlElement(nameof(FullName))]
        public string FullName { get; set; } = null!;

        [Required]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        [XmlElement(nameof(Email))]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(CustomerPhoneNumberMaxLength)]
        [MaxLength(CustomerPhoneNumberMaxLength)]
        [RegularExpression(CustomerPhoneNumberRegex)]
        [XmlAttribute("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;
    }
}
