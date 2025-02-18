using System; 

namespace ExerciseTracking
{
    public abstract class Activity
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; } // in minutes

        protected Activity(DateTime date, int duration)
        {
            Date = date;
            Duration = duration;
        }

        public abstract string GetSummary();
    }
}