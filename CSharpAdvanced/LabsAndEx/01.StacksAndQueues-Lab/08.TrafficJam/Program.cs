namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsPassingCount = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int passedCars = 0;

            string input;
            while ((input = Console.ReadLine()) != "end") // Read cars
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsPassingCount; i++)
                    {
                        if (cars.Count <= 0)
                            break;

                        Console.WriteLine(cars.Dequeue() + " passed!");
                        passedCars++;
                    }
                }
                else // Add car
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine(passedCars + " cars passed the crossroads.");
        }
    }
}
