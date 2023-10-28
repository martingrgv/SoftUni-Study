internal class Program
{
    static void Main(string[] args)
    {
        List<Article> articles = new List<Article>();
        int articlesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < articlesCount; i++)
        {
            string[] inputArticle = Console.ReadLine().Split(", ");

            string title = inputArticle[0];
            string content = inputArticle[1];
            string author = inputArticle[2];

            Article currentArticle = new Article(title, content, author);
            articles.Add(currentArticle);
        }

        foreach (Article article in articles)
        {
            Console.WriteLine(article.ToString());
        }
    }
}