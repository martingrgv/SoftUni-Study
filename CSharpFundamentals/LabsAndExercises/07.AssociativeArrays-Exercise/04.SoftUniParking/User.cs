class User : Parking
{
    public string Username { get; set; }
    public string LicensePlate { get; set; }

    public User(string username)
    {
        Username = username;
    }

    public User(string username, string licensePlate)
    {
        Username = username;
        LicensePlate = licensePlate;
    }

    public override string ToString()
    {
        return $"{Username} => {LicensePlate}";
    }
}
