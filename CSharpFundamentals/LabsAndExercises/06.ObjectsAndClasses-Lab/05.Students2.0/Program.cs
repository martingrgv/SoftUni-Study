namespace _05.Students2._0;
internal class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        string[] input = Console.ReadLine().Split(" ");

        AddStudents(students, input);

        string city = Console.ReadLine();

        List<Student> homeTownStudents = students.Where(s => s.HomeTown == city).ToList();

        foreach (var student in homeTownStudents)
        {
            System.Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
        }
    }

    public static void AddStudents(List<Student> students, string[] input)
    {
        while (input[0] != "end")
        {
                Student student = new Student(
                    input[0],
                    input[1],
                    int.Parse(input[2]),
                    input[3]);

            if (!IsStudentExisting(students, input[0], input[1]))
            {
                students.Add(student);
            }
            else
            {
                // OVERWRITE EXISTING STUDENT!
            }

            input = Console.ReadLine().Split(" ");
        }
    }

    static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
    {
        foreach (var student in students)
        {
            if (student.FirstName == firstName && student.LastName == lastName)
            {
                return true;
            }
        }

        return false;
    }
}