using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal total = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string username = GetToken(input, @"%([A-Z][a-z]+)%");
                Product product = GetProduct(input);

                if (UserExists(username, product))
                {
                    System.Console.WriteLine($"{username}: {product.Name} - {product.Total:f2}");
                    total += product.Total;
                }
            }
            
            System.Console.WriteLine($"Total income: {total:f2}");
        }

        private static string GetToken(string input, string pattern) => Regex.Match(input, pattern).Groups[1].Value;

        private static Product GetProduct(string input)
        {
            string productName = GetToken(input, @"<(\w+)>");
            string quantityString = GetToken(input, @"\|(\d+)\|");
            string priceString = GetToken(input, @"(\d+\.\d+|\d+)\$");

            if (IsTokenValid(productName) && 
                IsTokenValid(quantityString) && 
                IsTokenValid(priceString))
            {
                int quantity = int.Parse(quantityString);
                decimal price = decimal.Parse(priceString);

                return new Product(productName, price, quantity);
            }

            return null;
        }

        private static bool UserExists(string username, Product product)
        {
            if (username != string.Empty && product != null)
            {
                return true;
            }

            return false;
        }
        
        private static bool IsTokenValid(string token)
        {
            if (token != string.Empty)
            {
                return true;
            }

            return false;
        }
    }
}