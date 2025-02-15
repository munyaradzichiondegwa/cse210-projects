using System;
public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Bonus { get; set; }
    public int CompletedCount { get; set; } // Changed to public setter

    public ChecklistGoal(string name, string description, int value, int target, int bonus) : base(name, description, value)
    {
        Target = target;
        Bonus = bonus;
        CompletedCount = 0;
    }

    public override bool IsComplete() => CompletedCount >= Target;

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            CompletedCount++;
            if (IsComplete())
            {
                return Value + Bonus;
            }
            return Value;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {CompletedCount}/{Target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Value},{Bonus},{Target},{CompletedCount}";
    }
}