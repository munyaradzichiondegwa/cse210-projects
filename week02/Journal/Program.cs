
// Purpose: Create a journal entry class that has a prompt, response, and date.
//          The journal entry class should have a constructor that takes in a prompt and response.
//          The journal entry class should have a ToString method that returns the date, prompt, and response.
// Added category to the JournalEntry class (Exceed limit)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }
    public List<string> Tags { get; set; }
    public Location EntryLocation { get; set; }
    public Weather WeatherCondition { get; set; }

    public Entry(string prompt, string response, string mood, List<string> tags)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tags = tags ?? new List<string>();
        EntryLocation = new Location();
        WeatherCondition = new Weather();
    }

    public string GetEntryAsString()
    {
        string tagString = Tags.Count > 0 ? string.Join(", ", Tags) : "No tags";
        return $"Date: {Date}\n" +
               $"Mood: {Mood}\n" +
               $"Prompt: {Prompt}\n" +
               $"Response: {Response}\n" +
               $"Tags: {tagString}\n" +
               $"Location: {EntryLocation.City}, {EntryLocation.Country}\n" +
               $"Weather: {WeatherCondition.Condition}, {WeatherCondition.Temperature}°C\n";
    }

    public string GetEntryAsCSV()
    {
        string tagString = string.Join("|", Tags);
        return $"{Date}~|~{Prompt}~|~{Response}~|~{Mood}~|~{tagString}~|~" +
               $"{EntryLocation.City}~|~{EntryLocation.Country}~|~" +
               $"{WeatherCondition.Condition}~|~{WeatherCondition.Temperature}";
    }
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }

    public Location(string city = "", string country = "")
    {
        City = city;
        Country = country;
    }
}

public class Weather
{
    public string Condition { get; set; }
    public int Temperature { get; set; } // Assuming temperature in Celsius

    public Weather(string condition = "", int temperature = 0)
    {
        Condition = condition;
        Temperature = temperature;
    }
}
// Create User class with Username and Password properties

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

// week02/Journal/Journal.cs
// Added Search Functionality to Journal.cs (Exceed limits)
// Added Backup and Restore Functionality to Journal.cs (Exceed limits)
// Added Export to JSON Functionality to Journal.cs (Exceed limits)

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private static readonly string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What made me smile today?",
        "What challenges did I face today?",
        "What am I grateful for today?",
        "How can I improve tomorrow?"
    };

    private string lastPrompt;

    public void AddEntry(string response, string mood, List<string> tags)
    {
        var random = new Random();
        lastPrompt = prompts[random.Next(prompts.Length)];
        
        entries.Add(new Entry(lastPrompt, response, mood, tags));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.GetEntryAsString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.GetEntryAsCSV());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('~|~');
                if (parts.Length >= 8)
                {
                    List<string> tags = parts[4].Split('|').Select(t => t.Trim()).ToList();
                    entries.Add(new Entry(parts[2].Trim(), parts[3].Trim(), parts[1].Trim(), tags) 
                    { 
                        Date = parts[0].Trim(), 
                        EntryLocation = new Location(parts[6].Trim(), parts[7].Trim()), 
                        WeatherCondition = new Weather(parts[5].Trim(), int.Parse(parts[8].Trim())) 
                    });
                }
            }
        }
    }

    public void SearchEntries(string keyword)
    {
        var results = entries.Where(e => e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                                           e.Date.Contains(keyword)).ToList();
        if (results.Count > 0)
        {
            foreach (var entry in results)
            {
                Console.WriteLine(entry.GetEntryAsString());
            }
        }
        else
        {
            Console.WriteLine("No entries found.");
        }
    }

    public void BackupEntries(string backupPath)
    {
        SaveToFile(backupPath);
    }

    public void RestoreEntries(string backupPath)
    {
        LoadFromFile(backupPath);
    }

    public void ExportToJson(string filename)
    {
        var json = JsonSerializer.Serialize(entries);
        File.WriteAllText(filename, json);
    }

    public string GetLastPrompt()
    {
        return lastPrompt;
    }
}


// week02/Journal/Program.cs
class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        User currentUser = null;

        while (currentUser == null)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            currentUser = new User(username, password);
            Console.WriteLine($"Welcome, {currentUser.Username}!");
        }

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Backup journal");
            Console.WriteLine("7. Restore journal");
            Console.WriteLine("8. Export journal to JSON");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // Get the response from the user
                    Console.Write("Your response: ");
                    var response = Console.ReadLine();
                    
                    // Get the user's mood
                    Console.Write("Your mood: ");
                    var mood = Console.ReadLine();
                    
                    // Get tags from the user
                    Console.Write("Enter tags (comma separated): ");
                    var tagsInput = Console.ReadLine();
                    var tags = tagsInput?.Split(',').Select(t => t.Trim()).ToList() ?? new List<string>();
                    
                    // Get the prompt used in this entry
                    var prompt = journal.GetLastPrompt();
                    Console.WriteLine($"Using prompt: {prompt}");

                    // Add the entry to the journal
                    journal.AddEntry(response, mood, tags);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    var saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    var loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Enter keyword to search: ");
                    var keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;
                case "6":
                    Console.Write("Enter filename for backup: ");
                    var backupFilename = Console.ReadLine();
                    journal.BackupEntries(backupFilename);
                    break;
                case "7":
                    Console.Write("Enter filename to restore from: ");
                    var restoreFilename = Console.ReadLine();
                    journal.RestoreEntries(restoreFilename);
                    break;
                case "8":
                    Console.Write("Enter filename for export (JSON): ");
                    var exportFilename = Console.ReadLine();
                    journal.ExportToJson(exportFilename);
                    break;
                case "9":
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
