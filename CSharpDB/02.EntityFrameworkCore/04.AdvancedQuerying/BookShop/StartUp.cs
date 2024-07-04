namespace BookShop
{
    using Data;
    using System.Threading.Tasks;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    public class StartUp
    {
        public static async Task Main()
        {
            string command = Console.ReadLine();

            using var context = new BookShopContext();
            Console.WriteLine(GetBooksByAgeRestriction(context, command).Trim());
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
    }
}


