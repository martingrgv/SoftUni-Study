using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book? other)
        {
            int compareNum = this.Year.CompareTo(other.Year);

            if (compareNum == 0)
                compareNum = this.Title.CompareTo(other.Title);

            return compareNum;
        }

        public override string ToString() => $"{this.Title} - {this.Year}";
    }
}
