// path: week02/Journal/Program.cs
// Week 2 - Personal Journal with Tags and Mood Rating
// This program is an enhanced version of the Personal Journal program from Week 1.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Prompt Generator Class - Provides unique, randomized prompts
public class PromptGenerator
{
    private static readonly string[] _defaultPrompts = new[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I grateful for today?",
        "What challenge did I overcome today?",
        "What made me smile today?",
        "What did I learn about myself today?",
        "What goal am I working towards?"
    };

    private List<string> _usedPrompts = new List<string>();
    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        // If all prompts have been used, reset the list
        if (_usedPrompts.Count >= _defaultPrompts.Length)
        {
            _usedPrompts.Clear();
        }

        // Find an unused prompt
        string prompt;
        do
        {
            prompt = _defaultPrompts[_random.Next(_defaultPrompts.Length)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }
}

// Entry Class - Represents a single journal entry
public class JournalEntry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public int Mood { get; }  // Added mood rating
    public List<string> Tags { get; }  // Added tags for categorization

    public JournalEntry(string prompt, string response, int mood = 5, List<string> tags = null)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Mood = Math.Clamp(mood, 1, 10);  // Mood rating from 1-10
        Tags = tags ?? new List<string>();
    }

    // Enhanced display method
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood Rating: {Mood}/10");
        Console.WriteLine($"Tags: {(Tags.Any() ? string.Join(", ", Tags) : "No tags")}");
        Console.WriteLine(new string('-', 50));
    }

    // Method to convert entry to CSV format
    public string ToCSV()
    {
        // Escape commas in the response and prompt
        string escapedPrompt = Prompt.Replace(",", "~");
        string escapedResponse = Response.Replace(",", "~");
        string escapedTags = string.Join(";", Tags).Replace(",", "~");

        return $"{Date},{escapedPrompt},{escapedResponse},{Mood},{escapedTags}";
    }

    // Static method to parse CSV back to JournalEntry
    public static JournalEntry FromCSV(string csvLine)
    {
        var parts = csvLine.Split(',');
        if (parts.Length < 5) throw new ArgumentException("Invalid CSV format");

        // Unescape commas
        string prompt = parts[1].Replace("~", ",");
        string response = parts[2].Replace("~", ",");
        int mood = int.Parse(parts[3]);
        List<string> tags = parts[4].Split(';', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(t => t.Replace("~", ","))
                                     .ToList();

        return new JournalEntry(prompt, response, mood, tags);
    }
}
