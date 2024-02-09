namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book book2 = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book book3 = new Book("The Documents in the Case", 1930);

            Library library = new Library();
            Library library2 = new Library(bookOne, book2, book3);

            foreach (var book in library2)
                Console.WriteLine(book.Title);

            //foreach (var book in library)
            //{
            //    Console.WriteLine(book.ToString());
            //}

            //foreach (var book in library2)
            //{
            //    Console.WriteLine(book.ToString());
            //    Console.WriteLine("-----------");
            //}
        }
    }
}
