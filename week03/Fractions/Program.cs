using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating fractions using different constructors
            Fraction fraction1 = new Fraction(); // 1/1
            Fraction fraction2 = new Fraction(6); // 6/1
            Fraction fraction3 = new Fraction(6, 7); // 6/7
            Fraction fraction4 = new Fraction(1, 3); // 1/3

            // Displaying fractions and their decimal values
            Console.WriteLine(fraction1.GetFractionString()); // 1/1
            Console.WriteLine(fraction1.GetDecimalValue()); // 1.0

            Console.WriteLine(fraction2.GetFractionString()); // 6/1
            Console.WriteLine(fraction2.GetDecimalValue()); // 6.0

            Console.WriteLine(fraction3.GetFractionString()); // 6/7
            Console.WriteLine(fraction3.GetDecimalValue()); // 0.8571428571428571

            Console.WriteLine(fraction4.GetFractionString()); // 1/3
            Console.WriteLine(fraction4.GetDecimalValue()); // 0.3333333333333333
        }
    }
}

