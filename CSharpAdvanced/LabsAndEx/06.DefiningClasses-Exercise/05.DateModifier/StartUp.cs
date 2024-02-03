namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();

        var difference = DateModifier.GetDateDifference(date1, date2);
        Console.WriteLine(difference);
    }
}
