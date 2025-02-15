public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int value) : base(name, description, value) { }

    public override bool IsComplete() => IsCompleted;

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Value;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsCompleted ? "X" : " ")}] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Value},{IsCompleted}";
    }
}