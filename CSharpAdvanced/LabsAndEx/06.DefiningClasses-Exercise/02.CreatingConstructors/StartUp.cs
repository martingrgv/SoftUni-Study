namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();
        Person p2 = new Person(20);
        Person p3 = new Person("Martin", 20);

        Console.WriteLine(p1.Name + '|' + p1.Age);
        Console.WriteLine(p2.Name + '|' + p2.Age);
        Console.WriteLine(p3.Name + '|' + p3.Age);
    }
}
