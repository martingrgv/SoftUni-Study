using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class PropertyOwnerExportDTO
    {
        [JsonProperty(nameof(PropertyIdentifier))]
        public string PropertyIdentifier { get; set; } = null!;

        [JsonProperty(nameof(Area))]
        public int Area { get; set; }

        [JsonProperty(nameof(Address))]
        public string Address { get; set; } = null!;

        [JsonProperty(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;

        [JsonProperty("Owners", Order = 1)]
        public ICollection<OwnerDTO> Owners = new List<OwnerDTO>();
    }

    public class OwnerDTO
    {
        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; } = null!;

        [JsonProperty(nameof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;
    }
}
