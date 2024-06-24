namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(" ");

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int passengers = int.Parse(command[1]);
                    wagons.Add(passengers);
                }
                else // Passengers
                {
                    int passengers = int.Parse(command[0]);
                    HandlePassengers(wagons, passengers, maxCapacityPerWagon);
                }
                command = Console.ReadLine().Split(" ");
            }

            string train = string.Join(" ", wagons);
            Console.WriteLine(train);
        }

        static void HandlePassengers(List<int> wagons, int passengers, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passengers <= maxCapacity)
                {
                    wagons[i] += passengers;
                    break;
                }
            }
        }
    }
}