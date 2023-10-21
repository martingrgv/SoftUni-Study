class Program
{
    private static void Main(string[] args)
    {
        int employeeMaxCapacity1 = int.Parse(Console.ReadLine());
        int employeeMaxCapacity2 = int.Parse(Console.ReadLine());
        int employeeMaxCapacity3 = int.Parse(Console.ReadLine());

        int maxCapacity = employeeMaxCapacity1 + employeeMaxCapacity2 + employeeMaxCapacity3;
        int studentsCount = int.Parse(Console.ReadLine());
        int hours = 0;

        while (studentsCount > 0)
        {
            hours++;

            if (hours % 4 == 0)
            {
                hours++;
            }

            studentsCount -= maxCapacity;
        }

        Console.WriteLine($"Time needed: {hours}h.");
    }
}