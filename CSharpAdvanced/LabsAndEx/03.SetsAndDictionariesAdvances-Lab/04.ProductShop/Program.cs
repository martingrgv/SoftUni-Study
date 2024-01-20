namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] shopArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                AddShops(shops, shopArgs);
            }

            shops = shops.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (var shop in shops)
            {
                string shopName = shop.Key;
                Dictionary<string, double> shopProducts = shop.Value;

                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shopProducts)
                {
                    string productName = product.Key;
                    double productPrice = product.Value;

                    Console.WriteLine($"Product: {productName}, Price: {productPrice}");
                }
            }
        }

        private static void AddShops(Dictionary<string, Dictionary<string,double>> shops, string[] shopArgs)
        {
            string shopName = shopArgs[0];

            if (!shops.ContainsKey(shopName))
            {
                shops.Add(shopName, new Dictionary<string, double>());
            }

            AddProducts(shops, shopName, shopArgs);
        }

        private static void AddProducts(Dictionary<string, Dictionary<string, double>> shops, string shopName, string[] shopArgs)
        {
            string product = shopArgs[1];
            double price = double.Parse(shopArgs[2]);

            shops[shopName].Add(product, price);
        }
    }
}
