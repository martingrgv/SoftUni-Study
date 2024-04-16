using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{
    private const string ALLOWED_PATH = "Master";
    
    public TeamLead(string name, string path) : base(name, path)
    {
        if (path != ALLOWED_PATH)
        {
            throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
        }
    }

    public override string ToString()
    {
        return $"{Name} ({GetType().Name}) - Currently working on {InProgress.Count} tasks.";
    }
}