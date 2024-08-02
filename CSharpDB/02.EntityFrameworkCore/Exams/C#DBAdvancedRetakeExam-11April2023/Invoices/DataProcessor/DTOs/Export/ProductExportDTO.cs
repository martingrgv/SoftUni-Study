using Invoices.Data.Enumerations;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.DTOs.Export
{
    public class ProductExportDTO
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = null!;

        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty(nameof(Category))]
        public string Category { get; set; } = null!;

        [JsonProperty(nameof(Clients), Order = 1)]
        public ICollection<ClientExportDTO> Clients = new List<ClientExportDTO>();
    }
}
