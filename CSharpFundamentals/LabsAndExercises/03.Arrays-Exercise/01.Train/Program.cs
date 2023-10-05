namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());
            int[] wagons = new int[wagonsCount];

            // Write to array
            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
            }

            // Read from array
            int totalPassengers = 0;

            foreach (int passengers in wagons)
            {
                Console.Write(passengers + " ");
                totalPassengers += passengers;
            }

            Console.WriteLine();
            Console.WriteLine(totalPassengers);
        }
    }
}