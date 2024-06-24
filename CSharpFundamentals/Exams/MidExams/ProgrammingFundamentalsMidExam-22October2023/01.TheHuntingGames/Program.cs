namespace _01.TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdventure = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());

            double waterPerPersonPerDay = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());

            double waterResource = playersCount * waterPerPersonPerDay * daysOfAdventure;
            double foodResource = playersCount * foodPerPersonPerDay * daysOfAdventure;

            int day = 0;

            while (groupEnergy > 0)
            {
                day++;
                double energyLost = double.Parse(Console.ReadLine());
                groupEnergy -= energyLost;

                if (groupEnergy <= 0)
                {
                    break;
                }

                if (day % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    waterResource -= waterResource * 0.30;
                }

                if (day % 3 == 0)
                {
                    groupEnergy += groupEnergy * 0.10;
                    foodResource -= foodResource / playersCount;
                }

                if (groupEnergy > 0 && daysOfAdventure - day <= 0)
                {
                    Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
                    return;
                }

            }

            Console.WriteLine($"You will run out of energy. You will be left with {foodResource:f2} food and {waterResource:f2} water.");
        }
    }
}
