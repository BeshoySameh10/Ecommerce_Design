namespace Ecommerce;


using System;
using System.Collections.Generic;

public static class CheckoutService
{
    public static void Checkout(Customer customer, Cart cart)
    {
        if (cart.IsEmpty())
            throw new InvalidOperationException("Cart is empty!");

        double subtotal = 0;
        double shipping = 0;
        List<IShippable> shippables = new();

        foreach (var item in cart.Items)
        {
            var product = item.Product;

            if (product.IsExpired())
                throw new InvalidOperationException($"{product.Name} is expired.");

            if (item.Quantity > product.Quantity)
                throw new InvalidOperationException($"{product.Name} is out of stock.");

            subtotal += item.TotalPrice;

            if (product is IShippable shipItem)
            {
                for (int i = 0; i < item.Quantity; i++)
                    shippables.Add(shipItem);

                shipping += 10 * item.Quantity;
            }
        }

        double total = subtotal + shipping;

        if (customer.Balance < total)
            throw new InvalidOperationException("Customer balance is insufficient.");

        
        foreach (var item in cart.Items)
            item.Product.Quantity -= item.Quantity;
        
        if (shippables.Count > 0)
            ShippingService.Ship(shippables);

        // Receipt
        Console.WriteLine("** Checkout receipt **");
        foreach (var item in cart.Items)
            Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.TotalPrice:0}");

        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal {subtotal:0}");
        Console.WriteLine($"Shipping {shipping:0}");
        Console.WriteLine($"Amount {total:0}");

        customer.Deduct(total);
    }
}

