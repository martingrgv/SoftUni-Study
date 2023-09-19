using System;

namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Input
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // Logic
            int estimatedTime = 30;
            minutes += estimatedTime;

            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }
            
            if (hours > 23)
            {
                hours = 0;
            }

            // Output
            Console.WriteLine("{0}:{1:00}", hours, minutes);
        }
    }
}