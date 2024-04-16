namespace TheContentDepartment.Models;

public class Exam : Resource
{
    private const int PRIORITY_LEVEL = 1;
    
    public Exam(string name, string creator) : base(name, creator, PRIORITY_LEVEL)
    {
    }
}