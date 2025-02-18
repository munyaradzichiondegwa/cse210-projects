using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2021, 3, 1), 30, 3.5),
                new Cycling(new DateTime(2021, 3, 2), 45, 15.5),
                new Swimming(new DateTime(2021, 3, 3), 60, 20)
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
