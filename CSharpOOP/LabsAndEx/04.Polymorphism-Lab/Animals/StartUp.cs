namespace Animals;
public class StartUp
{
    static void Main(string[] args)
    {
        Animal dog = new Dog("Djaro", "Parjoli");
        Animal cat = new Cat("Felix", "Whiskers");

        Console.WriteLine(dog.ExplainSelf() + Environment.NewLine + cat.ExplainSelf());
    }
}
