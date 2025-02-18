using System;

public class Swimming : Activity
{
    // Private member variable
    private int _laps;

    // Constructor
    public Swimming(DateTime date, int lengthMinutes, int laps) 
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    // Override methods for Swimming-specific calculations
    public override double GetDistance()
    {
        // Assuming 50 meters per lap, convert to miles
        return (_laps * 50.0 / 1000.0) * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }

    // Override GetSummary for Swimming
    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Swimming ({LengthMinutes} min)- " +
               $"Distance {GetDistance():0.1f} miles, " +
               $"Speed {GetSpeed():0.1f} mph, " +
               $"Pace: {GetPace():0.1f} min per mile";
    }
}