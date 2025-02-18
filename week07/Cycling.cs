using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        public double Speed { get; } // Speed in mph

        public Cycling(DateTime date, int duration, double speed) : base(date, duration)
        {
            Speed = speed;
        }

        public override string GetSummary()
        {
            return $"Cycling on {Date.ToShortDateString()}: Duration {Duration} minutes, Speed {Speed} mph";
        }
    }
}