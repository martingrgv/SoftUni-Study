using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class ContentMember : TeamMember
{
    private static readonly string[] ALLOWED_PATH = new[] { "CSharp", "JavaScript", "Python", "Java" };

    public ContentMember(string name, string path) : base(name, path)
    {
        if (!ALLOWED_PATH.Any(p => path == p))
        {
            throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
    }
}