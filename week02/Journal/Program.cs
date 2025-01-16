// path: week02/Journal/Program.cs
// Create Journal Program
// Create Entry for Journal

using System;
using System.Collections.Generic;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public string GetEntryAsString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string GetEntryAsCSV()
    {
        return $"{Date}~|~{Prompt}~|~{Response}";
    }
}

// Path: week02/Journal/Program.cs
// Create Journal PromptGenerator Class

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing you learned today?",
            "What is something kind you did for someone today?",
            "What is a goal you worked toward today?",
            "What made you smile today?",
            "What was the most challenging part of your day?"
        };
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
