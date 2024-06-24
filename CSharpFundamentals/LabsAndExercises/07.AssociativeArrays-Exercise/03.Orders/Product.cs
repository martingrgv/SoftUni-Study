internal class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    public Product(string name, decimal price, decimal quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void Update(decimal price, decimal quantity)
    {
        Price = price;
        Quantity += quantity;
    }

    public decimal TotalPrice => Price * Quantity;

    public override string ToString()
    {
        return $"{Name} -> {TotalPrice:f2}";
    }
}
