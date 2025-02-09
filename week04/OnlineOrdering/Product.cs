using System;
using System.Collections.Generic;
public class Product
{
    string id;
    string name;
    decimal price;
    int quantity;

    // Constructor to create product
    public Product(string id, string name, decimal price, int quantity)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    // Calculate total cost of the product
    public decimal GeTotalCost()
    {
        return price * quantity;
    }

    // get product details
    public string GetProductId() {return id; }
    public string GetName() {return name; }

}
