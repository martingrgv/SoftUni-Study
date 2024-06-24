using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    private string name;
    private string path;
    private List<string> inprogress;

    public TeamMember(string name, string path)
    {
        inprogress = new List<string>();
        
        Name = name;
        Path = path;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
            }

            name = value;
        }
    }

    public string Path
    {
        get { return path; }
        protected set { path = value; }
    }

    public IReadOnlyCollection<string> InProgress
    {
        get { return inprogress.AsReadOnly(); }
    }
    
    public void WorkOnTask(string resourceName)
    {
         inprogress.Add(resourceName);
    }

    public void FinishTask(string resourceName)
    {
        inprogress.Remove(resourceName);
    }
}