class Piece
{
    public string Name { get; set; }
    public string Composer { get; set; }
    public string Key { get; set; }

    public Piece(string name, string composer, string key)
    {
        Name = name;
        Composer = composer;
        Key = key;
    }
}