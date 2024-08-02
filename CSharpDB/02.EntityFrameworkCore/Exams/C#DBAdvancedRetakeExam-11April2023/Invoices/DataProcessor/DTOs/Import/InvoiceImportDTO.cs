using Invoices.Core.Attributes;
using Invoices.Data.Enumerations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Invoices.Core.ValidationConstants;

namespace Invoices.DataProcessor.DTOs.Import
{
    public class InvoiceImportDTO
    {
        [Required]
        [Range(InvoiceNumberMinLength, InvoiceNumberMaxLength)]
        [JsonProperty(nameof(Number))]
        public int Number { get; set; }

        [Required]
        [JsonProperty(nameof(IssueDate))]
        public DateTime IssueDate { get; set; }

        [Required]
        [DateComparison(nameof(IssueDate))]
        [JsonProperty(nameof(DueDate))]
        public DateTime DueDate { get; set; }

        [Required]
        [JsonProperty(nameof(Amount))]
        public decimal Amount { get; set; }

        [Required]
        [EnumDataType(typeof(CurrencyType))]
        [JsonProperty(nameof(CurrencyType))]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        [JsonProperty(nameof(ClientId))]
        public int ClientId { get; set; }
    }
}
