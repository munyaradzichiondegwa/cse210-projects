using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Address instances
        Address address1 = new Address("32 Braemar St", "Mt Pleasant", "Harare", "Zimbabwe");
        Address address2 = new Address("13 Keswick Avenue", "Dalesford 7", "Gweru", "Zimbabwe");

        // Create Customer instances
        Customer customer1 = new Customer("Patience Mupasi", address1);
        Customer customer2 = new Customer("Talent Masocha", address2);

        // Create Product instances
        Product product1 = new Product("Laptop", "P001", 999.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("Keyboard", "P003", 45.75, 1);
        Product product4 = new Product("Monitor", "P004", 149.99, 2);

        // Create Order instances and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display information for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}\n");
    }
}
