using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private ResourceRepository resources;
    private MemberRepository members;
    
    public Controller()
    {
        resources = new ResourceRepository();
        members = new MemberRepository();
    }
    
    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType != "TeamLead" && memberType != "ContentMember")
        {
            return $"{memberType} is not a valid member type.";
        }

        ITeamMember member;

        if (memberType == "TeamLead")
        {
            member = new TeamLead(memberName, path);
        }
        else
        {
            member = new ContentMember(memberName, path);
        }
        
        // Or isn't Csharp, Java...
        if (members.Models.Any(m => m.Path == member.Path))
        {
            return "Position is occupied.";
        }

        if (members.TakeOne(memberName) != null)
        {
            return $"{memberName} has already joined the team.";
        }

        members.Add(member);
        return $"{memberName} has joined the team. Welcome!";
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (resourceType != "Exam" && resourceType != "Workshop" && resourceType != "Presentation")
        {
            return $"{resourceType} type is not handled by Content Department.";
        }

        ITeamMember member = members.Models.FirstOrDefault(m => m.Path == path);

        if (member == null)
        {
            return $"No content member is able to create the {resourceName} resource.";
        }

        if (member.InProgress.Contains(resourceName))
        {
            return $"The {resourceName} resource is being created.";
        }

        IResource resource;

        if (resourceType == "Exam")
        {
            resource = new Exam(resourceName, member.Name);
        }
        else if (resourceType == "Workshop")
        {
            resource = new Workshop(resourceName, member.Name);
        }
        else
        {
            resource = new Presentation(resourceName, member.Name);
        }
        
        member.WorkOnTask(resourceName);
        resources.Add(resource);
        
        return $"{member.Name} created {resourceType} - {resourceName}.";
    }

    public string LogTesting(string memberName)
    {
        ITeamMember member = members.TakeOne(memberName);
        
        if (member == null)
        {
            return "Provide the correct member name.";
        }

        IResource highestPriorityResource =
            resources.Models.OrderBy(m => m.Priority).FirstOrDefault(m => m.IsTested == false && m.Creator == member.Name);

        // Or if any resources for team member not found return
        if (highestPriorityResource == null)
        {
            return $"{memberName} has no resources for testing.";
        }

        ITeamMember leader = members.Models.FirstOrDefault(m => m is TeamLead);
        member.FinishTask(highestPriorityResource.Name);
        
        leader.WorkOnTask(highestPriorityResource.Name);
        highestPriorityResource.Test();
        
        return $"{highestPriorityResource.Name} is tested and ready for approval.";
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource resource = resources.TakeOne(resourceName);

        if (resource.IsTested == false)
        {
            return $"{resourceName} cannot be approved without being tested.";
        }

        ITeamMember leader = members.Models.FirstOrDefault(m => m is TeamLead);

        if (isApprovedByTeamLead)
        {
            resource.Approve();
            leader.FinishTask(resource.Name);
            
            return $"{leader.Name} approved {resourceName}.";
        }

        resource.Test();
        return $"{leader.Name} returned {resourceName} for a re-test.";
    }

    public string DepartmentReport()
    {
        List<IResource> approvedResources = resources.Models.Where(m => m.IsApproved).ToList();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Finished Tasks:");

        foreach (var task in approvedResources)
        {
            sb.AppendLine("--" + task.ToString());
        }

        sb.AppendLine("Team Report:");
        List<ITeamMember> orderedMembers = members.Models.OrderByDescending(m => m is TeamLead).ToList();

        foreach (var member in orderedMembers)
        {
            if (member is TeamLead)
            {
                sb.AppendLine("--" + member.ToString());
            }
            else
            {
                sb.AppendLine(member.ToString());
            }
        }

        return sb.ToString().TrimEnd();
    }
}