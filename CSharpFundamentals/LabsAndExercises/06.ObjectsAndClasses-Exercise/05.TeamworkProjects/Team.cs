internal class Team
{
    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

    public Team()
    {
        Members = new List<string>();
    }

    public Team(string name, string creatorName)
    {
        Name = name;
        Creator = creatorName;
        Members = new List<string>();
    }

    public void AddMember(string member)
    {
        Members.Add(member);
    }

    public override string ToString()
    {
        return $"{Name}\n" +
               $"- {Creator}\n" +
               $"{GetMembersString()}";
    }

    public string GetMembersString()
    {
        Members = Members.OrderBy(n => n).ToList();

        string result = string.Empty;

        for (int i = 0; i < Members.Count - 1; i++)
        {
            result += $"-- {Members[i]}\n";
        }

        result += $"-- {Members[Members.Count - 1]}";

        return result;
    }
}
