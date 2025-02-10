using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> ListPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.";
    }

    public override void RunActivity()
    {
        StartActivity();

        Random random = new Random();
        string prompt = ListPrompts[random.Next(ListPrompts.Count)];
        Console.WriteLine(prompt);
        ShowCountdown(3);

        Console.WriteLine("Start listing items. Press Enter after each item.");
        int itemCount = 0;
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items!");
        EndActivity();
    }
}