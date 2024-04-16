using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class Resource : IResource
{
    private string name;
    private string creator;
    private int priority;
    private bool isTested;
    private bool isApproved;

    public Resource(string name, string creator, int priority)
    {
        isTested = false;
        isApproved = false;

        Name = name;
        Creator = creator;
        Priority = priority;
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

    public string Creator
    {
        get { return creator; }
        private set { creator = value; }
    }

    public int Priority
    {
        get { return priority; }
        private set { priority = value; }
    }

    public bool IsTested
    {
        get { return isTested; }
        private set { isTested = value; }
    }

    public bool IsApproved
    {
        get { return isApproved; }
        private set { isApproved = value; }
    }
    
    public void Test()
    {
        if (isTested == false) isTested = true;
        else isTested = false;
    }

    public void Approve()
    {
        isApproved = true;
    }

    public override string ToString()
    {
        return $"{Name} ({GetType().Name}), Created By: {Creator}";
    }
}