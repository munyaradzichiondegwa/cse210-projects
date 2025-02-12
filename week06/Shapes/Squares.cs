using System;

public class Square : Shape
{
    //Private side field
    private double _side;

    // Constructir
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public double GetSide()
    {
        return _side;
    }

     // Override GetArea method
    public override double GetArea()
    {
        return _side * _side;
    }
}