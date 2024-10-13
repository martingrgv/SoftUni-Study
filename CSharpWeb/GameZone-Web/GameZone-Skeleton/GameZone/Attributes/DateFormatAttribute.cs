using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GameZone.Attributes
{
    public class DateFormatAttribute : ValidationAttribute
    {
        private readonly string _dateFormat;

        public DateFormatAttribute(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success!;
            }

            if (value is DateTime dateTime)
            {
                if (dateTime.ToString(_dateFormat, CultureInfo.InvariantCulture) == dateTime.ToString("yyyy-MM-dd"))
                {
                    return ValidationResult.Success!;
                }
            }

            return new ValidationResult($"{validationContext.DisplayName} must be a valid date in the format {_dateFormat}.");
        }
    }
}
