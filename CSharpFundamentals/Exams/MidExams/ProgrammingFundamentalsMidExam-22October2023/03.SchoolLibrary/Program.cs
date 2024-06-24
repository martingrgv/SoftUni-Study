namespace _03.SchoolLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                                  .Split("&")
                                  .ToList();
            string[] command = Console.ReadLine()
                               .Split(" | ");

            while (command[0] != "Done")
            {
                if (command[0] == "Add Book")
                {
                    string name = command[1];

                    if (!books.Contains(name))
                    {
                        books.Insert(0, name);
                    }
                }
                else if (command[0] == "Take Book")
                {
                    string name = command[1];

                    if (books.Contains(name))
                    {
                        books.Remove(name);
                    }
                }
                else if (command[0] == "Swap Books")
                {
                    if (command.Length == 3)
                    {
                        string book1 = command[1];
                        string book2 = command[2];

                        if (books.Contains(book1) && books.Contains(book2))
                        {
                            books = SwapBooks(books, book1, book2);
                        }
                    }
                }
                else if (command[0] == "Insert Book")
                {
                    string name = command[1];

                    if (!books.Contains(name))
                    {
                        books.Add(name);
                    }
                }
                else if (command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }
                }

                command = Console.ReadLine().Split(" | ");
            }

            Console.WriteLine(String.Join(", ", books));
        }

        static List<string> SwapBooks(List<string> books, string book1, string book2)
        {
            List<string> swappedBooks = new List<string>();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i] == book1)
                {
                    swappedBooks.Add(book2);
                }
                else if (books[i] == book2)
                {
                    swappedBooks.Add(book1);
                }
                else
                {
                    swappedBooks.Add(books[i]);
                }
            }

            return swappedBooks;
        }
    }
}