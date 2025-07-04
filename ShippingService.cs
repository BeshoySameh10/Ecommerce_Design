namespace Ecommerce;


using System;
using System.Collections.Generic;
using System.Linq;

public static class ShippingService
{
    public static void Ship(List<IShippable> shippables)
    {
        Console.WriteLine("\n** Shipment notice **");

        var grouped = shippables
            .GroupBy(s => s.GetName())
            .Select(g => new
            {
                Name = g.Key,
                Count = g.Count(),
                Weight = g.First().GetWeight()
            });

        double totalWeight = 0;

        foreach (var item in grouped)
        {
            double itemWeight = item.Weight * item.Count;
            totalWeight += itemWeight;
            Console.WriteLine($"{item.Count}x {item.Name} {(itemWeight * 1000):0}g");
        }

        Console.WriteLine($"Total package weight {totalWeight:0.0}kg");
    }
}

