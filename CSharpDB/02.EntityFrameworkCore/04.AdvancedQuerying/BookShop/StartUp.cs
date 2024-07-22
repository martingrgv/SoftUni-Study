namespace BookShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            using var context = new BookShopContext();
            Console.WriteLine(CountCopiesByAuthor(context));
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

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var compareDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books 
                .Where(b => b.ReleaseDate < compareDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsFullNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authorsFullNames);
        }

        // Fix
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Select(b => b.Title)
                .Where(t => t.Contains(input.ToLower()))
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        // Fix
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthors = context.Books
                .Include(a => a.Author)
                .Where(b => b.Author.LastName.StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => b.Title + " " +
                    "(" + b.Author.FirstName + b.Author.LastName + ")")
                .ToList();

            return string.Join(Environment.NewLine, booksByAuthors);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsBooks = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BooksCount = a.Books.Count
                })
                .OrderByDescending(a => a.BooksCount)
                .ToList();

            return string.Join(Environment.NewLine, authorsBooks.Select(a => a.FullName + " - " + a.BooksCount));
        }
    }
}


