namespace BookShop
{
    using BookShop.Models;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            using var context = new BookShopContext();
            Console.WriteLine(GetBooksByCategory(context, "horror mystery drama").Trim());
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

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString();
        }
        
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title);

            StringBuilder sb = new();
            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categoriesInput = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var titles = context.BooksCategories
                .Include(bc => bc.Book)
                .Include(bc => bc.Category)
                .Where(bc => categoriesInput.Contains(bc.Category.Name.ToLower())) 
                .Select(bc => bc.Book.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }
    }
}


