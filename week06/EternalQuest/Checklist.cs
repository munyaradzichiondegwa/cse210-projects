namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int Target { get; set;} // The number of times the goal must be completed
        public int CompletedCount { get; private set; } // The number of times the goal has been completed

        public ChecklistGoal(string name, int value, int target) : base(name, value)
        {
            Target = target;
            CompletedCount = 0;
        }

        public overide bool IsComplete() => CompletedCount >= Target;

        public override void RecordEvent()
        {
            if (!IsComplete())
            {
                CompletedCount++;
            }
        }
    }
}