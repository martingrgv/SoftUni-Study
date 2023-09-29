namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int day = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(weekdays[day - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}