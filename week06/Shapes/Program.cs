using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>
        {
            new Circle("Red", 3),
            new Rectangle("Blue", 2, 3),
            new Square("Green", 5)
        };

        // Loop through the list and print the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine(); // Add a blank line for readability
        }
    }
}