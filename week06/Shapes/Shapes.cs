using System;

public class Shape
{ 
  //Private color field
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Virtual method to be iverridden by derived classes
    public virtual double GetArea()
    {
        return 0;
    }
}
