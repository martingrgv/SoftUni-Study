namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Product>();

            AddProducts(products);

            foreach (var product in products)
            {
                Console.WriteLine(product.Value.ToString());
            }
        }

        static void AddProducts(Dictionary<string, Product> products)
        {
            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] arguments = input.Split();

                string productName = arguments[0];
                decimal productPrice = decimal.Parse(arguments[1]);
                decimal productQuantity = decimal.Parse(arguments[2]);

                if (products.ContainsKey(productName))
                {
                    products[productName].Update(productPrice, productQuantity);
                }
                else
                {
                    Product product = new Product(productName, productPrice, productQuantity);
                    products.Add(productName, product);
                }
            }
        }
    }
}