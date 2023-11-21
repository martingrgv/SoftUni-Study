using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Price * Quantity; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string username = GetUsername(input);

                if (username != string.Empty)
                {
                    Product p = GetProduct(input);

                    if (p.Name != null)
                    {
                        if (products.ContainsKey(username))
                        {
                            products[username] = p;
                        }
                        else
                        {
                            products.Add(username, p);
                        }
                    }
                }
            }

            PrintTotalIncome(products);
        }

        private static string GetUsername(string input)
        {
            string pattern = @"%(?<User>[A-Z][a-z]+)%.*?<(?<Product>\w+)>.*?\|(?<Quantity>\d+)\|.*?(?<Price>\d+\.\d+|\d+)\$";
            Match match = Regex.Match(input, pattern);

            return match.Groups["User"].Value;
        }

        private static Product GetProduct(string input)
        {
            string pattern = @"%(?<User>[A-Z][a-z]+)%.*?<(?<Product>\w+)>.*?\|(?<Quantity>\d+)\|.*?(?<Price>\d+\.\d+|\d+)\$";
            Match match = Regex.Match(input, pattern);

            if (Regex.IsMatch(input, pattern))
            {
                string productName = match.Groups["Product"].Value;
                int productQuantity = int.Parse(match.Groups["Quantity"].Value);
                decimal productPrice = decimal.Parse(match.Groups["Price"].Value);

                Product p = new Product();
                p.Name = productName;
                p.Quantity = productQuantity;
                p.Price = productPrice;

                return p;
            }

            return new Product();
        }

        private static void PrintTotalIncome(Dictionary<string, Product> products)
        {
            decimal total = 0;

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value.Name} - {product.Value.Total:f2}");
                total += product.Value.Total;
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}