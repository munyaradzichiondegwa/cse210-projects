using System;
using System.Collections.Generic;
using System.Reflection.Emit;

public class Order
{
    List<Product> productList;
    Customer orderCustomer; 

    // Constructor to create an order
    public Order(Customer customer)
    {
        orderCustomer = customer;
        productList = new List<Product>();
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        productList.Add(product);
    }

    // Calculate total order cost including shipping
    public decimal CalculateTotal()
    {
        decimal total = 0;

        // Sum up the cost of all products
        foreach (Product product in productList)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost based on location
        if (orderCustomer.LivesInZimbabwe())
        {
            total += 15; // local shipping
        }
        else
        {
            total += 75; // International Shipping
        }

        return total;
    }

    // Create a packing lable with product details
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in productList)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
        
    }

    // Create a shipping label with customer address
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{orderCustomer.GetName()}\n{orderCustomer.GetAddress().GetFullAddress()}";
    }
}
