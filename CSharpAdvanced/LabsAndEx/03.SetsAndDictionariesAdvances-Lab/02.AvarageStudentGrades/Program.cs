namespace _02.AvarageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentRecord = new Dictionary<string, List<double>>();

            // Populate record
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] student = Console.ReadLine().Split();
                string studentName = student[0];
                double grade = double.Parse(student[1]);

                if (studentRecord.ContainsKey(studentName))
                {
                    studentRecord[studentName].Add(grade);
                    continue;
                }

                studentRecord.Add(studentName, new List<double>() { grade });
            }

            foreach (var student in studentRecord)
            {
                Console.Write($"{student.Key} -> ");
                double studentAverageGrade = 0;

                foreach (var grade in student.Value)
                {
                    Console.Write(grade + " ");

                    studentAverageGrade += grade;
                }

                studentAverageGrade /= student.Value.Count;

                Console.Write($"(avg: {studentAverageGrade:F2})");
                Console.WriteLine();
            }

        }
    }
}
