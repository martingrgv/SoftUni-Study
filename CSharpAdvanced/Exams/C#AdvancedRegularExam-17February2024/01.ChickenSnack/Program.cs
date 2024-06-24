namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new Stack<int>(Console.ReadLine()
                                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray());

            Queue<int> prices = new Queue<int>(Console.ReadLine()
                                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray());

            int change = 0;
            int eatenCount = 0;

            while (money.Count > 0 && prices.Count > 0)
            {
                int currentMoney = money.Peek();
                int currentPrice = prices.Peek();

                if (change > 0)
                {
                    money.Push(money.Pop() + change);
                    currentMoney = money.Peek();

                    change = 0;
                }

                if (currentMoney == currentPrice) // Remove both
                {
                    eatenCount++;

                    money.Pop();
                    prices.Dequeue();
                }
                else if (currentMoney > currentPrice) // Get difference
                {
                    eatenCount++;
                    change = money.Pop() - prices.Dequeue();
                }
                else // No eating
                {
                    money.Pop();
                    prices.Dequeue();
                }
            }

            if (eatenCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {eatenCount} foods.");
            }
            else if (eatenCount > 1)
            {
                Console.WriteLine($"Henry ate: {eatenCount} foods.");
            }
            else if (eatenCount == 1)
            {

                Console.WriteLine($"Henry ate: {eatenCount} food.");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
