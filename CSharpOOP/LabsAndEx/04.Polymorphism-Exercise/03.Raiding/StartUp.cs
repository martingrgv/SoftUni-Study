using Raiding.Models;

namespace Raiding;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<BaseHero> raidGroup = new List<BaseHero>();

        int playersCount = int.Parse(Console.ReadLine());
        while (raidGroup.Count < playersCount)
        {
                string name = Console.ReadLine();
                string playerClass = Console.ReadLine();

                if (playerClass == "Druid") raidGroup.Add(new Druid(name));
                else if (playerClass == "Paladin") raidGroup.Add(new Paladin(name));
                else if (playerClass == "Rogue") raidGroup.Add(new Rogue(name));
                else if (playerClass == "Warrior") raidGroup.Add(new Warrior(name));
                else Console.WriteLine("Invalid hero!");
        }

        
        int bossPower = int.Parse(Console.ReadLine());
        int raidGroupDamage = raidGroup.Sum(r => r.Power);

        foreach (var hero in raidGroup)
            Console.WriteLine(hero.CastAbility());

        if (raidGroupDamage >= bossPower) Console.WriteLine("Victory!");
        else Console.WriteLine("Defeat...");
    }
}