namespace Invoices.DataProcessor
{
    using Cadastre.Utilities;
    using Invoices.Data;
    using Invoices.DataProcessor.DTOs.Export;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clientsWithInvoices = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate >= date))
                .Select(c => new ClientExportDTO
                {
                    Name = c.Name,
                    NumberVat = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i => i.DueDate)
                    .Select(i => new InvoiceExportDTO
                    {
                        InvoiceNumber = i.Number,
                        InvoiceAmount = i.Amount,
                        DueDate = i.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        Currency = i.CurrencyType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(c => c.Invoices.Length)
                .ThenBy(c => c.Name)
                .ToArray();

            var xmlResult = XmlSerializerHelper.Serialize(clientsWithInvoices, "Clients");

            return xmlResult;
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p =>
                    p.ProductsClients.Any(pc => pc.Client != null) &&
                    p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ProductExportDTO
                {
                    Name = p.Name,
                    Price = Math.Round(p.Price, 2),
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                    .Where(pc => pc.Client.Name.Length >= nameLength)
                    .Select(pc => new ClientExportDTO
                    {
                        Name = pc.Client.Name,
                        NumberVat = pc.Client.NumberVat
                    })
                    .OrderBy(c => c.Name)
                    .ToList()
                })
                .OrderByDescending(p => p.Clients.Count)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonSerializerHelper.Serialize(products);
        }
    }
}