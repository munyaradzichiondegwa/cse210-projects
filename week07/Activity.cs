using System;

public class Activity
{
    // Private member variables
    private DateTime _date;
    private int _lenthMinutes;

    // Constructor
    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lenthMinutes = lengthMinutes;
    }

    // Getters for private members
    public DateTime Date => _date;
    public int LengthMinutes => _lenthMinutes;

    // Virtual method to be overridden by derived classes
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    // GetSummary method eith virtusl implementation
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MM yyyy")} Unknown Activity ({_lenthMinutes} min.)";
    }
}