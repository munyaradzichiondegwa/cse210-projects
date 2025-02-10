using System;
using System.Collections.Generic;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> ReflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void RunActivity()
    {
        StartActivity();

        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int elapsedTime = 0;
        while (elapsedTime < Duration)
        {
            string question = ReflectionQuestions[random.Next(ReflectionQuestions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
            elapsedTime += 5;
        }

        EndActivity();
    }
}