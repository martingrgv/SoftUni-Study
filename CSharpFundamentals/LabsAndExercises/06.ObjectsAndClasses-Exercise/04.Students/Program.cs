namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string fname = input[0];
                string lname = input[1];
                double grade = double.Parse(input[2]);

                Student currentStudent = new Student(fname, lname, grade);
                students.Add(currentStudent);
            }

            students = students.OrderBy(student => student.Grade).ToList();
            students.Reverse();

            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}