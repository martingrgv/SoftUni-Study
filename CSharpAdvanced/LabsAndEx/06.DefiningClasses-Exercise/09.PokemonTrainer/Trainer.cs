namespace DefiningClasses;

public class Trainer
{
    public Trainer()
    {
        this.Pokemons = new List<Pokemon>();
        this.Badges = 0;
    }

    public Trainer(string name) : this()
    {
        this.Name = name;
    }

    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public bool HasPokemonOfElement(string element) => this.Pokemons.Any(p => p.Element == element);

    public void AddPokemon(Pokemon pokemon) => this.Pokemons.Add(pokemon);

    public void IncreaseBadges() => this.Badges++;

    public void DamageAllPokemons() => this.Pokemons.ForEach(p => p.Health -= 10);

    public void RemoveDeadPokemons() => this.Pokemons.RemoveAll(p => p.Health <= 0);

}
