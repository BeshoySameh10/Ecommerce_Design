namespace Ecommerce;

public  class Product
{
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public virtual bool IsExpired() => false;
    
}