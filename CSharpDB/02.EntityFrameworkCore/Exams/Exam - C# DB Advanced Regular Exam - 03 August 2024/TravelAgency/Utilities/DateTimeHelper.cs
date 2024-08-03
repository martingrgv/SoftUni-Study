using System.Globalization;

namespace Invoices.Utilities
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertTo(string dateToConvert, string format = "yyyy-MM-dd")
        {
            string date = dateToConvert;

            if (dateToConvert.Contains('T'))
            {
                date = dateToConvert.Substring(0, dateToConvert.IndexOf('T'));
            }

            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }
    }
}
