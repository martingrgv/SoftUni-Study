namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input
            byte peopleCount = byte.Parse(Console.ReadLine());
            byte capacity = byte.Parse(Console.ReadLine());

            // Logic
            float elevatorCourses = (float)(Math.Ceiling((double)peopleCount / capacity));

            // Output
            Console.WriteLine(elevatorCourses);
        }
    }
}