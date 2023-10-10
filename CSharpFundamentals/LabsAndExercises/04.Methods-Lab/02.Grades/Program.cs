using System.Security.Cryptography;

namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            string state = GetGradeState(grade);

            Console.WriteLine(state);
        }

        static string GetGradeState(double grade)
        {
            if (grade >= 2.00 && grade <= 2.99)
            {
                return "Fail";
            }
            else if (grade >= 3.00 && grade <= 3.49)
            {
                return "Poor";
            }
            else if (grade >= 3.50 && grade <= 4.49)
            {
                return "Good";
            }
            else if (grade >= 4.50 && grade <= 5.49)
            {
                return "Very good";
            }
            else
            {
                return "Excellent";
            }
        }
    }
}