using System;
using System.Collections.Generic;

// Address class definition
public class Address
{
  private string streetAddress;
  private string city;
  private string country;
  public Address(string streetAddress, string city, string country)
  {
    this.streetAddress = streetAddress;
    this.city = city;
    this.country = country;
  }

  public bool IsInZimbabwe()
  {
    return country.Equals("Zimbabwe", StringComparison.OrdinalIgnoreCase);
  }

  public string GetFullAddress()
  {
    return $"{streetAddress}\n{city}\n{country}";
  }
}
