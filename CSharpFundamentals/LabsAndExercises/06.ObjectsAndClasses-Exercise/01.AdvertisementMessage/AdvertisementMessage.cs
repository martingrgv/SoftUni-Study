internal class Messanger
{
    string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
    string[] events = new[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
    string[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
    string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

    string phrase;
    string @event;
    string author;
    string city;

    public void GenerateMessage()
    {
        GetRandomPhrase();
        GetRandomEvent();
        GetRandomAuthor();
        GetRandomCity();

        Console.WriteLine($"{phrase} {@event} {author} - {city}");
    }

    void GetRandomPhrase()
    {
        Random rnd = new Random();
        phrase = phrases[rnd.Next(0, phrases.Length - 1)];
    }

    void GetRandomEvent()
    {
        Random rnd = new Random();
        @event = events[rnd.Next(0, events.Length - 1)];
    }

    void GetRandomAuthor()
    {
        Random rnd = new Random();
        author = authors[rnd.Next(0, authors.Length - 1)];
    }

    void GetRandomCity()
    {
        Random rnd = new Random();
        city = cities[rnd.Next(0, cities.Length - 1)];
    }
}
