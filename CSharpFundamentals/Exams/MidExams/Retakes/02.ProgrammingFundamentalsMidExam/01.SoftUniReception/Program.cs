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

       AnswerQuestions(maxCapacity, studentsCount, hours);

    }

    private static void AnswerQuestions(int maxCapacity, int studentsCount, int hours)
    {
        int studentsLeft = studentsCount - maxCapacity;

        // Apply break
        if (hours % 4 == 0)
        {
            hours++;
        }

        if (studentsLeft > 0)
        {
            hours++;
            studentsCount -= maxCapacity;
            AnswerQuestions(maxCapacity, studentsCount, hours);
        }
        else
        {
            System.Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}