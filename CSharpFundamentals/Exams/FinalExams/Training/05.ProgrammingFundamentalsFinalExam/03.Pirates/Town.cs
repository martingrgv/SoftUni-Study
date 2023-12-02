public class Town
{
    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }

    public Town(string townName, int townPopulation, int townGold)
    {
        Name = townName;
        Population = townPopulation;
        Gold = townGold;
    }
}
