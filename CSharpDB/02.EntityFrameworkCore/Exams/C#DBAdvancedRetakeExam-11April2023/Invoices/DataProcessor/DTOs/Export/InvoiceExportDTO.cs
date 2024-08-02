using System.Xml.Serialization;

namespace Invoices.DataProcessor.DTOs.Export
{
    [XmlType("Invoice")]
    public class InvoiceExportDTO
    {
        [XmlElement(nameof(InvoiceNumber))]
        public int InvoiceNumber { get; set; }

        [XmlElement(nameof(InvoiceAmount))]
        public decimal InvoiceAmount { get; set; }

        [XmlElement(nameof(DueDate))]
        public string DueDate { get; set; } = null!;

        [XmlElement(nameof(Currency))]
        public string Currency { get; set; } = null!;
    }
}
