using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Capacity <= 0)
                return;

            if (Stall.Contains(product))
                return;

            Stall.Add(product);
            Capacity--;
        }

        public bool RemoveProduct(string name)
        {
            if (Stall.Any(p => p.Name == name))
            {
                Stall.RemoveAll(p => p.Name == name);

                Capacity++;
                return true;
            }

            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            if (!Stall.Any(p => p.Name == name))
                return "Product not found";

            Product product = Stall.FirstOrDefault(p => p.Name == name);

            double totalPrice = Math.Round(product.Price * quantity, 2);
            Turnover += totalPrice;

            return $"{product.Name} - {totalPrice:F2}$";
        }

        public string GetMostExpensive() => Stall.MaxBy(p => p.Price).ToString();

        public string CashReport() => $"Total Turnover: {Turnover:F2}$";

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Groceries Price List:");

            foreach (var product in Stall)
            {
                sb.AppendLine(product.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
