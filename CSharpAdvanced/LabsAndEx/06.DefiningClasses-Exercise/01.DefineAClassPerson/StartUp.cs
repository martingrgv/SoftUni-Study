namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person p1 = new Person();
        Person p2 = new Person();
        Person p3 = new Person();

        p1.Name = "Peter";
        p2.Name = "George";
        p3.Name = "Jose";

        p1.Age = 20;
        p2.Age = 18;
        p3.Age = 43;
    }
}
