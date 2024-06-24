namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = GetTeams();

            SeparateMembers(teams);

            List<Team> passedTeams = GetPassedTeams(teams);

            List<Team> orderedTeams = GetOrderedByDescending(passedTeams);
            orderedTeams.ForEach(t => Console.WriteLine(t.ToString()));

            Console.WriteLine("Teams to disband:");

            List<Team> disbandTeams = GetEliminatedTeams(teams);

            List<Team>orderedDisbandTeams = disbandTeams.OrderBy(t => t.Name).ToList();
            orderedDisbandTeams.ForEach(t => Console.WriteLine(t.Name));

        }

        static List<Team> GetTeams()
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                Team currentTeam = GetTeam();

                if (TeamNameExists(teams, currentTeam.Name))
                {
                    Console.WriteLine($"Team {currentTeam.Name} was already created!");
                    continue;
                }

                if (TeamCreatorExists(teams, currentTeam.Creator))
                {
                    Console.WriteLine($"{currentTeam.Creator} cannot create another team!");
                    continue;
                }

                teams.Add(currentTeam);
                Console.WriteLine($"Team {currentTeam.Name} has been created by {currentTeam.Creator}!");
            }

            return teams;
        }

        static Team GetTeam()
        {
            string[] input = Console.ReadLine().Split('-');
            string teamName = input[1];
            string teamCreator = input[0];

            Team team = new Team(teamName, teamCreator);

            return team;
        }

        static Team GetTeam(List<Team> teams, string teamName)
        {
            Team sameNameTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (sameNameTeam != null)
            {
                return sameNameTeam;
            }

            return null;
        }

        static bool TeamNameExists(List<Team> teams, string teamName) => teams.Any(t => t.Name == teamName);

        static bool TeamCreatorExists(List<Team> teams, string teamCreator) => teams.Any(t => t.Creator == teamCreator);

        static bool MemberCanJoin(List<Team> teams, string member)
        {
            if (teams.Any(t => t.Creator == member) ||
                teams.Any(t => t.Members.Contains(member)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void SeparateMembers(List<Team> teams)
        {
            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = input.Split("->");
                string user = arguments[0];
                string teamName = arguments[1];

                if (!TeamNameExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (!MemberCanJoin(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                Team team = GetTeam(teams, teamName);
                team.AddMember(user);
            }
        }

        static List<Team> GetPassedTeams(List<Team> teams) => teams.Where(t => t.Members.Count > 0).ToList();

        static List<Team> GetEliminatedTeams(List<Team> teams) => teams.Where(t => t.Members.Count <= 0).ToList();

        static List<Team> GetOrderedByDescending(List<Team> leftTeams) => leftTeams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();
    }
}