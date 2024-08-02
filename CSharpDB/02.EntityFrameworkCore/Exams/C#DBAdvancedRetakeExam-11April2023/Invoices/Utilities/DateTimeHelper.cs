using System.Globalization;

namespace Invoices.Utilities
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertTo(this string dateToConvert, string format = "yyyy-MM-dd")
        {
            string dateOnly = dateToConvert.Substring(0, dateToConvert.IndexOf('T'));
            return DateTime.ParseExact(dateOnly, format, CultureInfo.InvariantCulture);
        }
    }
}
