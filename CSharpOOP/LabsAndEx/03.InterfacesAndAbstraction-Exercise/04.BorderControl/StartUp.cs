using BorderControl.Interfaces;
using BorderControl.Models;

namespace BorderControl;
class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> population = new List<IIdentifiable>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split();

            if (data.Length == 2)
            {
                population.Add(new Robot(data[0], data[1]));
            }
            else
            {

                population.Add(new Citizen(data[0], int.Parse(data[1]), data[2]));
            }    
        }

        List<IIdentifiable> detainedIdentities = new List<IIdentifiable>();

        string fakeId = Console.ReadLine();

        for (int i = 0; i < population.Count; i++)
        {
            bool canDetain = true;

            for (int j = population[i].Id.Length - fakeId.Length, idCounter = 0; j < population[i].Id.Length; j++)
            {
                if (population[i].Id[j] != fakeId[idCounter++])
                {
                    canDetain = false;
                    break;
                }
            }

            if (canDetain)
            {
                detainedIdentities.Add(population[i]);
            }
        }

        foreach (var identity in detainedIdentities)
        {
            Console.WriteLine(identity.Id);
        }
    }
}