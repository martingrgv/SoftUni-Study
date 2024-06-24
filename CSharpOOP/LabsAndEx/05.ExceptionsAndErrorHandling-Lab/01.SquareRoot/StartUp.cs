namespace ExceptionHandling;

public class StartUp
{
    public static void Main(string[] args)
    {
        try
        {
            int number = GetNumber();
            Console.WriteLine(Math.Sqrt(number));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye.");
        }
    }

    private static int GetNumber()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return 0;
    }
}