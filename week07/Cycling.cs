using System;

public class Cycling : Activity
{
    // Private member variable
    private double _speed;

    // Constructor
    public Cycling(DateTime date, int lengthMinutes, double speed) : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    // Override methods for Cycling-specific calculations
    public override double GetDistance()
    {
        return (_speed / 60) * LengthMinutes;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    // Override GetSummary for Cycling
    public override string GetSummary()
    {
        return $"{Date.ToString("dd MM yyyy")} Cycling ({LengthMinutes} min.)-" +
               $"Distance {GetDistance():0.1f} miles, " +
               $"Speed {GetSpeed():0.1f} mph, " +
               $"Pace: {GetPace():0.1f} min/mile";
    }
}