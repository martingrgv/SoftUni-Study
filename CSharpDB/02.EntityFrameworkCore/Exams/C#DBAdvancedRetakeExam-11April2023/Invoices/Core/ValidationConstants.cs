using System;

namespace Invoices.Core
{
    public static class ValidationConstants
    {
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;

        public const int AddressStreetNameMinLength = 10;
        public const int AddressStreetNameMaxLength = 20;
        public const int AddressCityNameMinLength = 5;
        public const int AddressCityNameMaxLength = 15;
        public const int AddressCountryNameMinLength = 5;
        public const int AddressCountryNameMaxLength = 15;

        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;
    }
}
