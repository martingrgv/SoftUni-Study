namespace TheContentDepartment.Models;

public class Workshop : Resource
{
    private const int PRIORITY_LEVEL = 2;
    
    public Workshop(string name, string creator) : base(name, creator, PRIORITY_LEVEL)
    {
    }
}