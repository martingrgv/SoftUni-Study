internal class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int HP { get; set; }

    public Vehicle(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        HP = horsepower;
    }

    public override string ToString()
    {
        return $"Type: {Type[0].ToString().ToUpper()}{Type.Substring(1)}\n" +
               $"Model: {Model}\n" +
               $"Color: {Color}\n" +
               $"Horsepower: {HP}";
    }
}
