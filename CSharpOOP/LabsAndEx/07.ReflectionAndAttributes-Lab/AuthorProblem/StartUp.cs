namespace AuthorProblem;

[Author("Victor")]
class StartUp
{
    [Author("George")]
    public static void Main(string[] args)
    {
        Tracker tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}
