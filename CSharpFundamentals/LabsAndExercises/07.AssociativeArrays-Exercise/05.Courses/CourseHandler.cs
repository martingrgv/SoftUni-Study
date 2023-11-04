 class CourseHandler
{
    static Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

    public static void AddCourses()
    {
        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            string[] args = input.Split(":", StringSplitOptions.TrimEntries);

            string courseName = args[0];
            string studentName = args[1];

            if (courses.ContainsKey(courseName))
            {
                courses[courseName].Add(studentName);
            }
            else
            {
                courses.Add(courseName, new());
                courses[courseName].Add(studentName);
            }
        }
    }

    public static void PrintCourses()
    {
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Key}: {course.Value.Count}");
            
            foreach (var studentName in course.Value)
            {
                Console.WriteLine($"-- {studentName}");
            }
        }
    }
}
