using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Cadastre.Data.Enumerations;
using static Cadastre.Common.Constants.ValidationConstants;

namespace Cadastre.Data.Models
{
    public class Citizen
    {
        [Key]
        public int Id  { get; set; }

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public  MaritalStatus MaritalStatus { get; set; }

        public ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new List<PropertyCitizen>();
    }
}
