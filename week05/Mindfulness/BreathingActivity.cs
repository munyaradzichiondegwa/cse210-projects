using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void RunActivity()
    {
        StartActivity();

        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
            elapsedTime += 6;
        }

        EndActivity();
    }
}