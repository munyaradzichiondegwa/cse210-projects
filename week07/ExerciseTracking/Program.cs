using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
     class Program
    {
        static void Main()
        {
            var activities = new List<Activity>
            {
                new Running(new DateTime(2021, 10, 1), 30, 3.5),
                new Cycling(new DateTime(2021, 10, 2), 45, 15.5),
                new Swimming(new DateTime(2021, 10, 3), 60, 40)
            };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }

}







