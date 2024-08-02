using System;

namespace Invoices.Core
{
    public static class ValidationConstants
    {
        // Product
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;
        public const decimal ProductPriceMinLength = 5M;
        public const decimal ProductPriceMaxLength = 1000M;

        //Address
        public const int AddressStreetNameMinLength = 10;
        public const int AddressStreetNameMaxLength = 20;
        public const int AddressCityNameMinLength = 5;
        public const int AddressCityNameMaxLength = 15;
        public const int AddressCountryNameMinLength = 5;
        public const int AddressCountryNameMaxLength = 15;

        // Client
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;

        // Invoice
        public const int InvoiceNumberMinLength = 1_000_000_000;
        public const int InvoiceNumberMaxLength = 1_500_000_000;
    }
}
