class Student
{
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public Student()
    {
        Grades = new List<double>();
    }

    public Student(string name)
    {
        Name = name;
    }

    public Student(string name, double grade)
    {
        Name = name;
        Grades = new List<double>();
        Grades.Add(grade);
    }

    public double AverageGrade
    {
        get
        {
            double sum = 0;
            Grades.ForEach(g => sum += g);

            return sum / Grades.Count;
        }
    }
}
