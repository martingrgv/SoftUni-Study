namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            int aphabeticalOrder = x.Title.CompareTo(y.Title);

            if (aphabeticalOrder == 0)
                return y.Year.CompareTo(x.Year);

            return aphabeticalOrder;
        }
    }
}
