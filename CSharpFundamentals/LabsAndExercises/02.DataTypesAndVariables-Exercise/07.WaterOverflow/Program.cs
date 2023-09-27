namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte tankCapacity = 255;
            short litresPoured = 0;
            byte readTimes = byte.Parse(Console.ReadLine());

            for (int i = 0; i < readTimes; i++)
            {
                short currentLitres = short.Parse(Console.ReadLine());

                if (currentLitres <= tankCapacity - litresPoured)
                {
                    litresPoured += currentLitres;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(litresPoured);
        }
    }
}