using System;
using System.Collections.Generic;

// Address class definition
public class Address
{
    
    // Adress details
  string street;
  string city;
  string country;

  // Constructor to create an address
  public Address(string street, string city, string country)
  {
    this.street = street;
    this.city = city;
    this.country = country;
  }

    // Check if the address is in Zimbabwe
  public bool IsInZimbabwe()
  {
    return country.ToLower() == "zimbabwe";
  }
    
    //Get the full address 
  public string GetFullAddress()
  {
    return $"{street}\n{city}\n{country}";
  }
}
