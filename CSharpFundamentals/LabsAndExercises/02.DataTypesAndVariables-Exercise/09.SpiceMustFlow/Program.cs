namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yieldSource = int.Parse(Console.ReadLine());
            int yieldStored = 0;
            int daysOperated = 0;

            while (yieldSource >= 100)
            {
                yieldStored += yieldSource - 26;

                daysOperated++;
                yieldSource -= 10;
            }
            if (yieldStored > 26)
            {
                yieldStored -= 26;
            }

            Console.WriteLine(daysOperated);
            Console.WriteLine(yieldStored);
        }
    }
}