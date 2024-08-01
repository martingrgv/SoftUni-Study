namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using static Common.Constants.ValidationConstants;

    [JsonObject(nameof(Citizen))]
    public class ImportCitizenDto
    {
        [Required]
        [MinLength(NAME_MIN_LENGTH)]
        [MaxLength(NAME_MAX_LENGTH)]
        [JsonProperty(nameof(FirstName))]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(NAME_MIN_LENGTH)]
        [MaxLength(NAME_MAX_LENGTH)]
        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(BirthDate))]
        public string BirthDate { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        [JsonProperty(nameof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        [JsonProperty(nameof(Properties))]
        public int[] Properties { get; set; } = null!;
    }
}
