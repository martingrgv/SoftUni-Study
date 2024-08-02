using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.DTOs.Export
{
    [XmlType("Client")]
    public class ClientExportDTO
    {
        [XmlElement("ClientName")]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement("VatNumber")]
        [JsonProperty(nameof(NumberVat))]
        public string NumberVat { get; set; } = null!;

        [XmlAttribute(nameof(InvoicesCount))]
        [JsonIgnore]
        public int InvoicesCount { get; set; }

        [XmlArray(nameof(Invoices))]
        [JsonIgnore]
        public InvoiceExportDTO[] Invoices { get; set; } = null!;
    }
}
