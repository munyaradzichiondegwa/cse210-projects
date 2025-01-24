// Fraction.cs
public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor with no parameters
    public Fraction()
    {
        this.numerator = 1;
        this.denominator = 1;
    }

    // Constructor with one parameter for numerator
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        this.denominator = 1;
    }

    // Constructor with two parameters for numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getters and setters for numerator and denominator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    // Method to return the fraction in the form "numerator/denominator"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
