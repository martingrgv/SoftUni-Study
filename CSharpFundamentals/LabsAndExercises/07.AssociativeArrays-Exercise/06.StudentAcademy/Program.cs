namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = AddStudents();
            PrintStudents(students);
        }

        static Dictionary<string, Student> AddStudents()
        {
            var students = new Dictionary<string, Student>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                Student student = new Student(name);

                if (students.ContainsKey(student.Name))
                {
                    students[student.Name].Grades.Add(grade);
                }
                else
                {
                    student = new Student(name, grade);
                    students.Add(student.Name, student);
                }
            }

            var passedStudents = new Dictionary<string, Student>();
            foreach (var student in students)
            {
                if (student.Value.AverageGrade >= 4.50)
                {
                    passedStudents.Add(student.Key, student.Value);
                }
            }

            return passedStudents;
        }

        static void PrintStudents(Dictionary<string, Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.AverageGrade:f2}");
            }
        }
    }
}