namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArticle = Console.ReadLine().Split(", ");
            int numberOfCommands = int.Parse(Console.ReadLine());

            string title = inputArticle[0];
            string content = inputArticle[1];
            string author = inputArticle[2];

            Article article = new Article(title, content, author);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Rename":
                        string newTitle = command[1];
                        article.Rename(newTitle);
                        break;
                    case "Edit":
                        string newContent = command[1];
                        article.Edit(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = command[1];
                        article.ChangeAuthor(newAuthor);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}