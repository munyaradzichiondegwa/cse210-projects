using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        public double Distance { get; } // Distance in miles

        public Running(DateTime date, int duration, double distance) : base(date, duration)
        {
            Distance = distance;
        }

        public override string GetSummary()
        {
            return $"Running on {Date.ToShortDateString()}: Duration {Duration} minutes, Distance {Distance} miles";
        }
    }
}