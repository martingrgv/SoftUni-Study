using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Title);
            sb.AppendLine(Year.ToString());

            if (Authors.Count > 0)
            {
                foreach (var author in Authors)
                {
                    sb.AppendLine(author);
                }
            }
            else
            {
                sb.Append("Annonymous");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
