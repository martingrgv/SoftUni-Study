namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split();
                string username = command[1];

                switch(command[0])
                {
                    case "register":
                        string licensePlate = command[2];
                        User user = new User(username, licensePlate);

                        Parking.Register(user);
                        break;
                    case "unregister":
                        user = new User(username);

                        Parking.Unregister(user);
                        break;
                }
            }

            Parking.PrintParkingLot();
        }
    }
}