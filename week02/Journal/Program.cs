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
