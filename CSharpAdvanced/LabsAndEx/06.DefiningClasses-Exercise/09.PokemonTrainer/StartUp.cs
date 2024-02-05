namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        string input;
        while ((input = Console.ReadLine()) != "Tournament") // Add trainers
        {
            string[] inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Trainer trainer = new Trainer(inArgs[0]);
            Pokemon pokemon = new Pokemon(inArgs[1], inArgs[2], int.Parse(inArgs[3]));
            trainer.AddPokemon(pokemon);

            if (trainers.Any(t => t.Name == trainer.Name))
            {
                trainer = trainers.FirstOrDefault(t => t.Name == trainer.Name);
                trainer.AddPokemon(pokemon);

            }
            else
            {
                trainers.Add(trainer);
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string element = input;

            foreach (var trainer in trainers)
            {
                if (trainer.HasPokemonOfElement(element))
                {
                    trainer.IncreaseBadges();
                }
                else
                {
                    trainer.DamageAllPokemons();
                    trainer.RemoveDeadPokemons();
                }
            }
        }

        List<Trainer> orderedTrainers = trainers.OrderByDescending(t => t.Badges).ToList();
        orderedTrainers.ForEach(t => Console.WriteLine($"{t.Name} {t.Badges} {t.Pokemons.Count}"));
    }
}   
