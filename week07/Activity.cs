using System;

public class Activity
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Duration { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }

    public Activity(string name, DateTime date, TimeSpan duration, string location, string description)
    {
        Name = name;
        Date = date;
        Duration = duration;
        Location = location;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Name} on {Date.ToShortDateString()} at {Location}";
    }
}