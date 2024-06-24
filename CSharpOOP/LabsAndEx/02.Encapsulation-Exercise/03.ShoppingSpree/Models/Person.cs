namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name 
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        private IReadOnlyCollection<Product> ProductBag
        {
            get { return products.AsReadOnly(); }
        }

        public void AddProductToBag(Product product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{Name} - {string.Join(", ", products)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
