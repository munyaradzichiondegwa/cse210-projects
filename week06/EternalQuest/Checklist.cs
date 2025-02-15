using System;

namespace EternalQuest
{
    public class ChecklistGoalNew : Goal
    {
        public int Target { get; set;} // The number of times the goal must be completed
       public int CompletedCount { get; set; } // The number of times the goal has been completed

        public ChecklistGoalNew(string name, int value, int target) : base(name, value)
        {
            Target = target;
            CompletedCount = 0;
        }
        public override bool IsComplete() => CompletedCount >= Target;

        public override void RecordEvent()
        {
            if (!IsComplete())
            {
                CompletedCount++;
            }
        }
    }
}