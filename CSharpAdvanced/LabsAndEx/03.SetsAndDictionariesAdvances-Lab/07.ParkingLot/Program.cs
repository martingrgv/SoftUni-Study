namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                string carLicense = commandArgs[1];

                if (direction == "OUT")
                {
                    if (parkingLot.Contains(carLicense))
                    {
                        parkingLot.Remove(carLicense);
                    }

                    continue;
                }

                parkingLot.Add(carLicense);
            }

            if (parkingLot.Count <= 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in parkingLot)
                Console.WriteLine(car);
        }
    }
}
