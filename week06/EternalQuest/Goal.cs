using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    public bool IsCompleted { get; set; } // Changed to public setter

    protected Goal(string name, string description, int value)
    {
        Name = name;
        Description = description;
        Value = value;
        IsCompleted = false;
    }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}