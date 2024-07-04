namespace BookShop
{
    using Data;
    using System.Threading.Tasks;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;
    using System.Security.Cryptography.X509Certificates;

    public class StartUp
    {
        public static async Task Main()
        {
            using var context = new BookShopContext();
            Console.WriteLine(GetGoldenBooks(context).Trim());
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (Enum.TryParse(command, true, out AgeRestriction restriction))
            {
                var bookTitles = context.Books
                    .Where(b => b.AgeRestriction == restriction)
                    .Select(b => b.Title)
                    .OrderBy(t => t)
                    .ToList();

                StringBuilder sb = new StringBuilder();
                foreach (var title in bookTitles)
                {
                    sb.AppendLine(title);               
                }

                return sb.ToString().TrimEnd();
            }

            return string.Empty;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            StringBuilder sb = new();
            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString();
        }
    }
}


