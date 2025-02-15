using System;

namespace EternalQuest
{ 
    public class EternalGoalNew : Goal
    {
        public EternalGoalNew(string name, int value) : base(name, value) { }

        public override bool IsComplete() => false;
        public override void RecordEvent() { }
    }
}