using System.Transactions;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            double price = GetPrice(product, amount);
            double total = GetTotalPrice(price, amount);

            Console.WriteLine($"{total:f2}");
        }

        static double GetPrice(string product, int amount = 1)
        {
            switch (product)
            {
                case "coffee":
                    return 1.5;
                case "water":
                    return 1;
                case "coke":
                    return 1.4;
                case "snacks":
                    return 2;
            }
            return 0;
        }

        static double GetTotalPrice(double pricePerProduct, int amount = 1)
        {
            return pricePerProduct * amount;
        }
    }
}