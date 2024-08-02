using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace Invoices.Core.Attributes
{
    public class DateComparisonAttribute : ValidationAttribute
    {
        private string datePropertyName;

        public DateComparisonAttribute(string _biggerDatePropertyName)
        {
            datePropertyName = _biggerDatePropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(datePropertyName);
            var compareValue = propertyInfo!.GetValue(validationContext.ObjectInstance) as DateTime?;

            var currentDate = value as DateTime?;

            if (currentDate < compareValue)
            {
                return new ValidationResult($"{datePropertyName} is incorrect!");
            }

            return ValidationResult.Success;
        }
    }
}
