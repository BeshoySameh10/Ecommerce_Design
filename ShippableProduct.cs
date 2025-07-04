namespace Ecommerce;

public class ShippableProduct : Product, IShippable
{
    public double Weight { get; }

    public ShippableProduct(string name, double price, int quantity, double weight)
        : base(name, price, quantity)
    {
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
    
}