namespace _07.TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            string dayOfWeek = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            // Logic & Output
            if (age >= 0 && age <= 18)
            {
                if (dayOfWeek == "Weekday") Console.WriteLine("12$");
                if (dayOfWeek == "Weekend") Console.WriteLine("15$");
                if (dayOfWeek == "Holiday") Console.WriteLine("5$");
            }
            else if (age > 18 && age <= 64)
            {
                if (dayOfWeek == "Weekday") Console.WriteLine("18$");
                if (dayOfWeek == "Weekend") Console.WriteLine("20$");
                if (dayOfWeek == "Holiday") Console.WriteLine("12$");
            }
            else if (age > 64 && age <= 122)
            {
                if (dayOfWeek == "Weekday") Console.WriteLine("12$");
                if (dayOfWeek == "Weekend") Console.WriteLine("15$");
                if (dayOfWeek == "Holiday") Console.WriteLine("10$");

            }
            else // age is invalid
            {
                Console.WriteLine("Error!");
            }
        }
    }
}