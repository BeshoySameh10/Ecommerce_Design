using System;
namespace Ecommerce;
class Program
{
    static void Main(string[] args)
    {
        var cheese = new ShippableProduct("Cheese", 100, 5, 0.2); 
        var biscuits = new ShippableProduct("Biscuits", 150, 3, 0.7); 
        
        var tv = new ShippableProduct("TV", 2000, 2, 5.0); 
        //var scratchCard = new Product("Scratch Card", 50, 10) { };
        var customer = new Customer("Omar", 1000);

        var cart = new Cart();
        cart.Add(cheese, 2);       
        cart.Add(biscuits, 1);     
        //cart.Add(scratchCard, 10);  

        CheckoutService.Checkout(customer, cart);
    }
}