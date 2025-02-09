using System;
using System.Collections.Generic;

// Address class definition
public class Address
{
    // Properties
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    // Constructor with 4 arguments
    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

     // Check if the address is in Zimbabwe
    public bool IsInZimbabwe()
    {
        return Country.Equals("Zimbabwe", StringComparison.OrdinalIgnoreCase);
    }

    // Method to get the full address as a string
    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }


}