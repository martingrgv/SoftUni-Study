﻿class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get { return Price * Quantity; } }
}
