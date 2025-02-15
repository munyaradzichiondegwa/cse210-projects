// Base Class
using System;

namespace EternalQuest
{
    // Base Class for goals in the game
    public abstract class Goal
    {
        public string Name { get; set; }
        public int Value { get; set; }
        protected bool IsCompleted;

        protected Goal(string name, int value)
        {
            Name = name;
            Value = value;
            IsCompleted = false;
        }

        public abstract bool IsComplete();
        public abstract void RecordEvent();
    }

    // Class for simple goals
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int value) : base(name, value) { }

        public override bool IsComplete() => true;
        public override void RecordEvent() { }
    }

    // Class for eternal goals
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int value) : base(name, value) { }

        public override bool IsComplete() => false;
        public override void RecordEvent() { }
    }

    // Class for checklist goals
    public class ChecklistGoal : Goal
    {
        public int Target { get; set; }
        public int CompletedCount { get; private set; }


        public ChecklistGoal(string name, int value, int target) : base(name, value)
        {
            this.Target = target;
            this.CompletedCount = 0;
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
