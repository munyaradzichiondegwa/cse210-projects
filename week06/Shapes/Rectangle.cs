using System;

public class Rectangle : Shape
{
    // Private length and width fields
    private double _length;
    private double _width;

    //Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }
        
    // Overide GetArea method
    public override double GetArea()
    { 
        return _length * _width;
    }
}