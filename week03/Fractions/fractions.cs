using System;

namespace Fractions
{
    public class Fraction
    {
        // Private attributes for numerator and denominator
        private int numerator;
        private int denominator;

        // Constructor with no parameters
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
        }

        // Constructor with one parameter (numerator)
        public Fraction(int numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }

        // Constructor with two parameters (numerator and denominator)
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        // Getters and Setters
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator cannot be zero.");
                }
                denominator = value;
            }
        }

        // Method to return the fraction as a string
        public string GetFractionString()
        {
            return $"{numerator}/{denominator}";
        }

        // Method to return the decimal value
        public double GetDecimalValue()
        {
            return (double)numerator / denominator;
        }
    }
}