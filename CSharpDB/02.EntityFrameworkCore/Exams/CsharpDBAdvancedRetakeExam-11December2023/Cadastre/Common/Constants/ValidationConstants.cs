namespace Cadastre.Common.Constants;

public static class ValidationConstants
{
    public const int DISTRICT_NAME_MIN_LENGTH = 2;
    public const int DISTRICT_NAME_MAX_LENGTH = 80;
    public const int DISTRICT_POSTAL_CODE_MIN_LENGTH = 8;
    public const int DISTRICT_POSTAL_CODE_MAX_LENGTH = 8;
    public const string DISTRICT_POSTAL_CODE_REGEX = @"^[A-Z]{2}-\d{5}$";

    public const int PROPERTY_IDENTIFIER_MIN_LENGTH = 16;
    public const int PROPERTY_IDENTIFIER_MAX_LENGTH = 20;
    public const int PROPERTY_DETAILS_MIN_LENGTH = 5;
    public const int PROPERTY_DETAILS_MAX_LENGTH = 500;

    public const int ADDRESS_MIN_LENGTH = 5;
    public const int ADDRESS_MAX_LENGTH = 200;

    public const int NAME_MIN_LENGTH = 2;
    public const int NAME_MAX_LENGTH = 30;
}
