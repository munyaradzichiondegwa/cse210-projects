namespace EternalQuest
{
    // Class for simple goals
    public class BasicGoal : Goal
    {
        public BasicGoal(string name, int value) : base(name, value) { }

        public override bool IsComplete() => true;
        public override void RecordEvent() { }
    }
}