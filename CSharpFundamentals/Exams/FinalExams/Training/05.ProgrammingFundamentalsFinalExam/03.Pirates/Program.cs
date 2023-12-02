namespace _03.Pirates;
class Program
{
    static List<Town> towns = new();
    private static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "Sail")
            AddCities(input);
        
        while((input = Console.ReadLine()) != "End")
        {
            string[] inArgs = input.Split("=>");

            string act = inArgs[0];
            string townName = inArgs[1];

            switch (act)
            {
                case "Plunder":
                    int peopleCount = int.Parse(inArgs[2]);
                    int goldAmount = int.Parse(inArgs[3]);

                    PlunderTown(townName, peopleCount, goldAmount);
                    break;
                case "Prosper":
                    goldAmount = int.Parse(inArgs[2]);

                    ProsperTown(townName, goldAmount);
                    break;
            }
        }

        PrintTowns();
    }

    private static void AddCities(string input)
    {
        string[] inArgs = input.Split("||");
        string townName = inArgs[0];
        int townPopulation = int.Parse(inArgs[1]);
        int townGold = int.Parse(inArgs[2]);

        Town currentTown = new Town(townName, townPopulation, townGold);

        if (towns.Exists(t => t.Name == currentTown.Name))
        {
            Town existingTown = towns.FirstOrDefault(t => t.Name == currentTown.Name);

            existingTown.Population += currentTown.Population;
            existingTown.Gold += currentTown.Gold;
        }
        else
        {
            towns.Add(currentTown);
        }
    }

    private static void PlunderTown(string townName, int peopleCount, int goldAmount)
    {
        Town plunderTown = towns.FirstOrDefault(t => t.Name == townName);

        plunderTown.Population -= peopleCount;
        plunderTown.Gold -= goldAmount;

        System.Console.WriteLine($"{townName} plundered! {goldAmount} gold stolen, {peopleCount} citizens killed.");

        if (plunderTown.Population <= 0 || plunderTown.Gold <= 0)
        {
            towns.Remove(plunderTown);

            System.Console.WriteLine($"{townName} has been wiped off the map!");
        }
    }

    private static void ProsperTown(string townName, int goldAmount)
    {
        if (goldAmount < 0)
        {
            System.Console.WriteLine("Gold added cannot be a negative number!");
            return;
        }

        Town prosperTown = towns.FirstOrDefault(t => t.Name == townName);

        prosperTown.Gold += goldAmount;

        System.Console.WriteLine($"{goldAmount} gold added to the city treasury. {townName} now has {prosperTown.Gold} gold.");
    }

    private static void PrintTowns()
    {
        if (towns.Count > 0)
        {
            System.Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

            foreach (Town town in towns)
            {
                System.Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
            }
        }
        else
        {
            System.Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}
