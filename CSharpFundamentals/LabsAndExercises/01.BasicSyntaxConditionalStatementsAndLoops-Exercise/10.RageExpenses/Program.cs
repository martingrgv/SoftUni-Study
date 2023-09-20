namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int timesHeadsetDestroyed = lostGamesCount / 2;
            int timesMouseDestroyed = lostGamesCount / 3;
            int timesKeyboardDestroyed = lostGamesCount / 6;
            int timesDisplayDestroyed = lostGamesCount / 12;

            double headsetExpenses = headsetPrice * timesHeadsetDestroyed; 
            double mouseExpenses = mousePrice * timesMouseDestroyed; 
            double keyboardExpenses = keyboardPrice * timesKeyboardDestroyed; 
            double displayExpenses = displayPrice * timesDisplayDestroyed;

            double rageExpenses = headsetExpenses + mouseExpenses + keyboardExpenses + displayExpenses;
            Console.WriteLine("Rage expenses: {0:f2} lv.", rageExpenses);
        }
    }
}