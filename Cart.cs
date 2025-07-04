
using Ecommerce;

public class Cart
{
    public List<CartItem> items = new  List<CartItem>();

    public void Add(Product product, int quantity)
    {
        if (quantity > product.Quantity)
            throw new InvalidOperationException($"Not enough stock for {product.Name}");

        items.Add(new CartItem(product, quantity));
    }

    public List<CartItem> Items => items;
    public bool IsEmpty() => !items.Any();
}