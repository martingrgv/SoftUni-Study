namespace _05.Students2._0;
internal class Program
{
    public static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        string[] input = Console.ReadLine().Split(" ");

        AddStudents(students, input);

        string city = Console.ReadLine();
        PrintStudents(students, city);
    }

    public static void AddStudents(List<Student> students, string[] input)
    {
        while (input[0] != "end")
        {
            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);
            string homeTown = input[3];

            Student student = new Student(
                firstName,
                lastName,
                age,
                homeTown);

            if (!IsStudentExisting(students, firstName, lastName))
            {
                students.Add(student);
            }
            else
            {
                ChangeStudentInfo(students, student);
            }

            input = Console.ReadLine().Split(" ");
        }
    }

    static bool IsStudentExisting(Student student, Student currentStudent)
    {
        if (student.FirstName == currentStudent.FirstName && student.LastName == currentStudent.LastName)
        {
            return true;
        }

        return false;
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

    static void ChangeStudentInfo(List<Student> students, Student currentStudent)
    {
       foreach (var student in students)
       {
            if (IsStudentExisting(student, currentStudent)) 
            {
                student.FirstName = currentStudent.FirstName;
                student.LastName = currentStudent.LastName;
                student.Age = currentStudent.Age;
                student.HomeTown = currentStudent.HomeTown;
            }
       }
    }

    static void PrintStudents(List<Student> students, string city)
    {
        List<Student> homeTownStudents = students.Where(s => s.HomeTown == city).ToList();

        foreach (var student in homeTownStudents)
        {
            System.Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
        }
    }

}

 class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }

    public Student(string firstName, string lastName, int age, string homeTown)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.HomeTown = homeTown;
    }
}
