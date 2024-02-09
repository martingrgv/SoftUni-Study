using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private Book[] books;

        public Library(params Book[] books)
        {
            this.books = books;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly Book[] arr;
            private int index = -1;

            public LibraryIterator(Book[] arr)
            {
                this.Reset();
                this.arr = arr;
            }

            public Book Current => arr[index];

            object IEnumerator.Current => Current;

            public bool MoveNext() => ++index < this.arr.Length;

            public void Reset() => this.index = -1;

            public void Dispose()
            {

            }
        }
    }
}
