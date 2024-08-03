namespace TravelAgency.Core
{
    public static class ValidationConstants
    {
        // Customer
        public const int CustomerFullNameMinLength = 4;
        public const int CustomerFullNameMaxLength = 60;
        public const int CustomerEmailMinLength = 6;
        public const int CustomerEmailMaxLength = 50;
        public const int CustomerPhoneNumberMaxLength = 13;
        public const string CustomerPhoneNumberRegex = @"\+\d{12}";

        // Guide
        public const int GuideFullNameMinLength = 4;
        public const int GuideFullNameMaxLength = 60;

        // Tour Package
        public const int TourPackagePackageNameMinLength = 2;
        public const int TourPackagePackageNameMaxLength = 40;
        public const int TourPackageDescriptionMinLength = 0;
        public const int TourPackageDescriptionMaxLength = 200;
    }
}
