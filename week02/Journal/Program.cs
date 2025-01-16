
// Purpose: Create a journal entry class that has a prompt, response, and date.
//          The journal entry class should have a constructor that takes in a prompt and response.
//          The journal entry class should have a ToString method that returns the date, prompt, and response.
// Added category to the JournalEntry class (Exceed limit)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Category { get; set; }

    public JournalEntry(string prompt, string response, string category)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Category = category;
    }

    public override string ToString()
    {
        return $"{Date} | {Category} | {Prompt} | {Response}";
    }
}

// week02/Journal/UserInterface.cs (Exceed expectations)
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
    private List<JournalEntry> entries = new List<JournalEntry>();
    private static readonly string[] prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry(string response)
    {
        var random = new Random();
        var prompt = prompts[random.Next(prompts.Length)];
        
        Console.Write("Enter a category for this entry: ");
        var category = Console.ReadLine();
        
        entries.Add(new JournalEntry(prompt, response, category));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToString());
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
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    entries.Add(new JournalEntry(parts[2].Trim(), parts[3].Trim(), parts[1].Trim()) 
                    { 
                        Date = parts[0].Trim() 
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
                Console.WriteLine(entry);
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
                    Console.Write("Your response: ");
                    var response = Console.ReadLine();
                    journal.AddEntry(response);
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
