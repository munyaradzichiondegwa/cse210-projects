// path: week02/Journal/Program.cs
// Week 2 - Personal Journal with Tags and Mood Rating
// This program is an enhanced version of the Personal Journal program from Week 1.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

// User Management Class
public class UserManager
{
    private Dictionary<string, string> _users = new Dictionary<string, string>();
    private const string USER_FILE = "users.json";

    public UserManager()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        if (File.Exists(USER_FILE))
        {
            try
            {
                var jsonString = File.ReadAllText(USER_FILE);
                _users = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            }
            catch
            {
                _users = new Dictionary<string, string>();
            }
        }
    }

    private void SaveUsers()
    {
        var jsonString = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(USER_FILE, jsonString);
    }

    // Hash password using SHA256
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public bool RegisterUser(string username, string password)
    {
        // Check if username already exists
        if (_users.ContainsKey(username))
        {
            return false;
        }

        // Store hashed password
        _users[username] = HashPassword(password);
        SaveUsers();
        return true;
    }

    public bool AuthenticateUser(string username, string password)
    {
        if (!_users.ContainsKey(username))
        {
            return false;
        }

        // Compare hashed passwords
        return _users[username] == HashPassword(password);
    }
}

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
    private List<JournalEntry> _entries = new();
    private PromptGenerator _promptGenerator = new();

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
    static readonly UserManager userManager = new();
    static Journal currentJournal;

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            // If journal is initialized, show journal menu
            while (currentJournal != null)
            {
                if (!DisplayJournalMenu())
                {
                    break;
                }
            }
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("\n--- Personal Journal Application ---");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register New User");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = ReadPassword();

        if (userManager.AuthenticateUser(username, password))
        {
            Console.WriteLine($"Welcome, {username}!");
            currentJournal = new Journal();
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
    }

    static void Register()
    {
        Console.Write("Choose a username: ");
        string username = Console.ReadLine();
        Console.Write("Choose a password: ");
        string password = ReadPassword();

        if (userManager.RegisterUser(username, password))
        {
            Console.WriteLine("Registration successful!");
        }
        else
        {
            Console.WriteLine("Username already exists. Please choose another.");
        }
    }

    // Securely read password (mask input)
    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Ignore any non-printable characters
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[..^1];
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    static bool DisplayJournalMenu()
    {
        Console.WriteLine("\n--- Personal Journal Menu ---");
        Console.WriteLine("1. Write a New Entry");
        Console.WriteLine("2. Display All Entries");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Search Entries");
        Console.WriteLine("6. Export to JSON");
        Console.WriteLine("7. Logout");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddNewEntry(currentJournal);
                return true;
            case "2":
                currentJournal.DisplayEntries();
                return true;
            case "3":
                SaveJournal(currentJournal);
                return true;
            case "4":
                LoadJournal(currentJournal);
                return true;
            case "5":
                SearchJournal(currentJournal);
                return true;
            case "6":
                ExportJournalToJson(currentJournal);
                return true;
            case "7":
                currentJournal = null;
                Console.WriteLine("Logged out successfully.");
                return false;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                return true;
        }
    }

    static void AddNewEntry(Journal journal)
    {
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        Console.Write("Mood rating (1-10): ");
        int mood = int.Parse(Console.ReadLine());
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
