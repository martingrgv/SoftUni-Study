namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.IO.IsolatedStorage;
    using System.Text;
    using Cadastre.Utilities;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.DTOs.Import;
    using Invoices.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var clientsDTOs = XmlSerializerHelper.Deserialize<ClientImportDTO[]>(xmlString, "Clients");

            if (clientsDTOs == null)
            {
                throw new InvalidOperationException("Could not extract data from xml!");
            }

            var stringBuilder = new StringBuilder();
            var clients = new List<Client>();

            foreach (var dto in clientsDTOs)
            {
                if (!IsValid(dto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client
                {
                    Name = dto.Name,
                    NumberVat = dto.NumberVat
                };

                foreach (var addressDto in dto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var address = new Address
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country,
                    };

                    client.Addresses.Add(address);
                }

                clients.Add(client);
                stringBuilder.AppendLine(string.Format(
                    SuccessfullyImportedClients, client.Name
                ));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var invoicesDtos = JsonSerializerHelper.Deserialize<InvoiceImportDTO[]>(jsonString);

            if (invoicesDtos == null)
            {
                throw new InvalidOperationException("Could not extract data from json!");
            }

            var stringBuilder = new StringBuilder();
            var invoices = new List<Invoice>();

            foreach (var dto in invoicesDtos)
            {
                if (!IsValid(dto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var invoice = new Invoice
                {
                    Number = dto.Number,
                    IssueDate = DateTimeHelper.ConvertTo(dto.IssueDate),
                    DueDate = DateTimeHelper.ConvertTo(dto.DueDate),
                    Amount = dto.Amount,
                    CurrencyType = dto.CurrencyType,
                    ClientId = dto.ClientId
                };

                invoices.Add(invoice);
                stringBuilder.AppendLine(string.Format(
                    SuccessfullyImportedInvoices, invoice.Number
                ));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var productsDtos = JsonSerializerHelper.Deserialize<ProductImportDTO[]>(jsonString);

            if (productsDtos == null)
            {
                throw new InvalidOperationException("Could not extract data from json!");
            }

            var stringBuilder = new StringBuilder();
            var products = new List<Product>();

            foreach (var dto in productsDtos)
            {
                if (!IsValid(dto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    CategoryType = dto.CategoryType
                };

                var existingClientsIds = context.Clients
                    .Select(c => c.Id)
                    .ToArray();

                var clientIds = new HashSet<int>(dto.ClientsIds);

                foreach (var id in clientIds)
                {
                    if (!existingClientsIds.Contains(id))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient
                    {
                        ClientId = id
                    });
                }

                products.Add(product);

                stringBuilder.AppendLine(string.Format(
                    SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count
                ));
            }


            context.Products.AddRange(products);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
