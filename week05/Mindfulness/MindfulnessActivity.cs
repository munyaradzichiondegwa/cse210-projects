// Base Class representing general activity
using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected int Duration { get; private set; }
    protected string Name { get; set; }
    protected string Description { get; set; }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Welcome to the {Name} Activity!");
        Console.WriteLine(Description);
        
        Console.Write("How long would you like this session to last (in seconds)? ");
        Duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"Great job! You have completed the {Name} Activity.");
        Console.WriteLine($"You spent {Duration} seconds on this activity.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinnerChars = { "|", "/", "-", "\\" };
        int counter = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[counter % 4]);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            counter++;
            Thread.Sleep(250);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.WriteLine();
    }

    public abstract void RunActivity();
}