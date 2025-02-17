using System;

public class Running : Activity
{
    // Private member variables
    private double _distance;

    // Constructor
    public Running(DateTime date, int lengthMinutes, double distance) : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    // Overide methods for Running-specific calculations
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / LengthMinutes * 60;
    }

    public override double GetPace()
    {
        return LengthMinutes / _distance;
    }

    // Override GetSummary for Running
    public override string GetSummary()
    {
        return $"{Date.ToString("dd MM yyyy")} Running ({LengthMinutes} min.)-" +
               $"Distance {GetDistance():0.1f} miles, " +
               $"Speed {GetSpeed():0.1f} mph, " +
               $"Pace: {GetPace():0.1f} min/mile";
    }
}