using System;
using System.Collections.Generic;

public class Customer
{
    string name; 
    Address customerAddress;

    // Constructor to create a customer
    public Customer(string name, Address address)
    {
        this.name = name;
        this.customerAddress = address;
    }

    // Check if customer lives in Zimbabwe
    public bool LivesInZimbabwe()
    {
        return customerAddress.IsInZimbabwe();
    }

    // Get the customer name
    public string GetName()
    {
        return name;
    }

    // get customer address
    public Address GetAddress()
    {
        return customerAddress;
    }

}


