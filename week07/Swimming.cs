using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        public int Laps { get; } // Number of laps

        public Swimming(DateTime date, int duration, int laps) : base(date, duration)
        {
            Laps = laps;
        }

        public override string GetSummary()
        {
            return $"Swimming on {Date.ToShortDateString()}: Duration {Duration} minutes, Laps {Laps}";
        }
    }
}