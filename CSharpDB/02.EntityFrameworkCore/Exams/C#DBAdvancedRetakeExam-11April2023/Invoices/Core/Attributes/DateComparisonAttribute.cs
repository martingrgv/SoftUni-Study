using Invoices.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            var compareValue = propertyInfo!.GetValue(validationContext.ObjectInstance);

            var compareDate = DateTimeHelper.ConvertTo((compareValue as string)!);
            var currentDate = DateTimeHelper.ConvertTo((value as string)!);

            if (currentDate < compareDate)
            {
                return new ValidationResult($"{datePropertyName} is incorrect!");
            }

            return ValidationResult.Success;
        }
    }
}
