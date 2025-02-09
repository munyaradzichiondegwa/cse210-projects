using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create addresses
        Address zimbabweAddress = new("30 Braemar Street", "Mt Pleasant", "Harare", "Zimbabwe");
        Address southAfricaAddress = new("No.3 Jacob Mare Street", "Sunnyside", "Pretoria", "South Africa");

        // Create customers
        Customer zimbabweCustomer = new Customer("talent Masocha", zimbabweAddress);
        Customer foreignCustomer = new Customer("Sibonfile Tshabangu", southAfricaAddress);

        // Create products
        Product smartphone = new Product("001", "Smartphone", 150.00m, 1);
        Product headphones = new Product("002", "Headphones", 20.00m, 2);
        Product charger = new Product("003", "Charger", 10.00m, 1);

        // Create and process orders
        Order zimbabweOrder = new Order(zimbabweCustomer);
        zimbabweOrder.AddProduct(smartphone);
        zimbabweOrder.AddProduct(headphones);

        Order foreignOrder = new Order(foreignCustomer);
        foreignOrder.AddProduct(charger);
        foreignOrder.AddProduct(headphones);

        //Display order details
        Console.WriteLine("Zimbabwe Order:");
        Console.WriteLine(zimbabweOrder.GetPackingLabel());
        Console.WriteLine(zimbabweOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${zimbabweOrder.CalculateTotal()}\n");

        Console.WriteLine("Foreign Order:");
        Console.WriteLine(foreignOrder.GetPackingLabel());
        Console.WriteLine(foreignOrder.GetShippingLabel());
        Console.WriteLine($"Total Price: ${foreignOrder.CalculateTotal()}");

    }
}

    