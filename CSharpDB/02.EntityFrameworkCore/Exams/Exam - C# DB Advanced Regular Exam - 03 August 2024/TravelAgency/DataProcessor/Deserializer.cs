using Cadastre.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var customerDTOs = XmlSerializerHelper.Deserialize<CustomerImportDTO[]>(xmlString, "Customers");

            if (customerDTOs == null)
            {
                throw new InvalidOperationException("Could not extract data from XML!");
            }

            var strBuilder = new StringBuilder();
            var customers = new List<Customer>();
            var existingCustomers = context.Customers
                .AsNoTracking()
                .ToList();

            foreach (var dto in customerDTOs)
            {
                if (!IsValid(dto))
                {
                    strBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                if (CustomersExist(customers, dto) ||
                    CustomersExist(existingCustomers, dto))
                {
                    strBuilder.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };

                customers.Add(customer);
                strBuilder.AppendLine(string.Format(
                    SuccessfullyImportedCustomer, customer.FullName
                ));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return strBuilder.ToString().TrimEnd();
        }
        
        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage!;
            }

            return isValid;
        }

        private static bool CustomersExist(List<Customer> customers, CustomerImportDTO customerDTO)
        {
            return customers.Any(c =>
                    c.FullName == customerDTO.FullName ||
                    c.Email == customerDTO.Email ||
                    c.PhoneNumber == customerDTO.PhoneNumber);
        }
    }
}
