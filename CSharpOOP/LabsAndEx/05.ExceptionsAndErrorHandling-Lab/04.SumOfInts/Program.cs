namespace SumOfInts;

public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        string[] data = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < data.Length; i++)
        {
            try
            {
                sum += int.Parse(data[i]);
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The element '{data[i]}' is out of range!");
            }
            catch (FormatException)
            {
                Console.WriteLine($"The element '{data[i]}' is in wrong format!");
            }
            finally
            {
                Console.WriteLine($"Element '{data[i]}' processed - current sum: {sum}");
            }
        }

        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}