namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using Cadastre.Utilities;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.DTOs.Import;

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

            StringBuilder sb = new StringBuilder();
            var clients = new List<Client>();

            foreach (var dto in clientsDTOs)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
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
                        sb.AppendLine(ErrorMessage);
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
                sb.AppendLine(string.Format(
                    SuccessfullyImportedClients, client.Name
                ));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
