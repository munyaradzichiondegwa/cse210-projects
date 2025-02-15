using System;
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int value) : base(name, description, value) { }

    public override bool IsComplete() => false;

    public override int RecordEvent()
    {
        return Value;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Value}";
    }
}