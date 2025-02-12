using System;

public class Circle : Shape
{
    // Private radius field
    private double _radius;

    // Comstructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Overide GetArea method
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
