namespace _4.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int productCount = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 1; i <= productCount; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();

            for (int i = 1; i <= products.Count; i++)
            {
                Console.WriteLine($"{i}.{products[i - 1]}");
            }
        }
    }
}