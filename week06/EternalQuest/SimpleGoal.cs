namespace EternalQuest
{
    // Class for simple goals
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int value) : base(name, value) { }

        public override bool IsComplete() => true;
        public override void RecordEvent() { }
    }
}