class Parking
{
    static Dictionary<string, User> parkingData = new Dictionary<string, User>();

    public static void Register(User user)
    {
        if (parkingData.ContainsKey(user.Username))
        {
            Console.WriteLine($"ERROR: already registered with plate number {user.LicensePlate}");
        }
        else
        {
            parkingData.Add(user.Username, user);
            Console.WriteLine($"{user.Username} registered {user.LicensePlate} successfully");
        }
    }

    public static void Unregister(User user)
    {
        if (parkingData.ContainsKey(user.Username))
        {
            parkingData.Remove(user.Username);
            Console.WriteLine($"{user.Username} unregistered successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: user {user.Username} not found");
        }
    }

    public static void PrintParkingLot()
    {
        foreach (var user in parkingData)
        {
            Console.WriteLine(user.Value.ToString());
        }
    }
}
