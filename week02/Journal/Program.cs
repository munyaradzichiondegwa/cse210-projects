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

// Journal Class - Manages collection of journal entries
public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public string GetRandomPrompt() => _promptGenerator.GetRandomPrompt();

    public void AddEntry(string response, int mood = 5, List<string> tags = null)
    {
        string prompt = GetRandomPrompt();
        var entry = new JournalEntry(prompt, response, mood, tags);
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (!_entries.Any())
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            File.WriteAllLines(filename, _entries.Select(e => e.ToCSV()));
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            var lines = File.ReadAllLines(filename);
            _entries.Clear();
            _entries.AddRange(lines.Select(JournalEntry.FromCSV));
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public void ExportToJson(string filename)
    {
        var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal exported to {filename}");
    }

    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e => 
            e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Tags.Any(t => t.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        if (results.Any())
        {
            Console.WriteLine("Matching Entries:");
            results.ForEach(e => e.Display());
        }
        else
        {
            Console.WriteLine("No matching entries found.");
        }
    }

    public int GetEntryCount() => _entries.Count;
}

// Main Program Class
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    SearchJournal(journal);
                    break;
                case "6":
                    ExportJournalToJson(journal);
                    break;
                case "7":
                    Console.WriteLine("Thank you for journaling today!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- Personal Journal ---");
        Console.WriteLine("1. Write a New Entry");
        Console.WriteLine("2. Display All Entries");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Search Entries");
        Console.WriteLine("6. Export to JSON");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
    }

    static void AddNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Mood rating (1-10, default 5): ");
        int mood;
        if (!int.TryParse(Console.ReadLine(), out mood))
        {
            mood = 5;
        }

        Console.Write("Tags (comma-separated): ");
        var tags = Console.ReadLine()
            ?.Split(',')
            .Select(t => t.Trim())
            .Where(t => !string.IsNullOrEmpty(t))
            .ToList();

        journal.AddEntry(response, mood, tags);
        Console.WriteLine("Entry added successfully!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter search keyword: ");
        string keyword = Console.ReadLine();
        journal.SearchEntries(keyword);
    }

    static void ExportJournalToJson(Journal journal)
    {
        Console.Write("Enter filename for JSON export: ");
        string filename = Console.ReadLine();
        journal.ExportToJson(filename);
    }
}