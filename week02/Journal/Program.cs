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

// Utility Class for Secure Operations
public static class SecurityUtils
{
    // Generate a secure salt
    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        RandomNumberGenerator.Fill(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    // Hash password with salt
    public static string HashPassword(string password, string salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            Convert.FromBase64String(salt),
            iterations: 10000,
            HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(20);
            return Convert.ToBase64String(hash);
        }
    }
}

// User Model
public class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public DateTime CreatedAt { get; set; }
}

// User Repository for Managing User Data
public class UserRepository
{
    private const string USER_FILE = "users.json";
    private List<User> _users;

    public UserRepository()
    {
        LoadUsers();
    }

    private void LoadUsers()
    {
        if (File.Exists(USER_FILE))
        {
            try
            {
                string jsonContent = File.ReadAllText(USER_FILE);
                _users = JsonSerializer.Deserialize<List<User>>(jsonContent)
                         ?? new List<User>();
            }
            catch
            {
                _users = new List<User>();
            }
        }
        else
        {
            _users = new List<User>();
        }
    }

    private void SaveUsers()
    {
        string jsonContent = JsonSerializer.Serialize(_users,
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(USER_FILE, jsonContent);
    }

    public bool RegisterUser(string username, string password)
    {
        // Check if username already exists
        if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        // Create new user
        string salt = SecurityUtils.GenerateSalt();
        var newUser = new User
        {
            Username = username,
            Salt = salt,
            PasswordHash = SecurityUtils.HashPassword(password, salt),
            CreatedAt = DateTime.Now
        };

        _users.Add(newUser);
        SaveUsers();
        return true;
    }

    public bool ValidateUser(string username, string password)
    {
        var user = _users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (user == null) return false;

        // Verify password
        string hashedPassword = SecurityUtils.HashPassword(password, user.Salt);
        return hashedPassword == user.PasswordHash;
    }
}

// Journal Entry Model
public class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }
    public int Mood { get; set; }
    public List<string> Tags { get; set; }

    public JournalEntry()
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Tags = new List<string>();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry: {Content}");
        Console.WriteLine($"Mood: {new string('❤', Mood)}{new string('♡', 10 - Mood)}");
        Console.WriteLine($"Tags: {string.Join(", ", Tags)}");
        Console.WriteLine(new string('-', 50));
    }
}

// Prompt Generator
public class PromptGenerator
{
    private static readonly string[] _prompts = new[]
    {
        "What was the most meaningful moment of your day?",
        "What are you grateful for today?",
        "What challenged you today?",
        "What made you smile today?",
        "What did you learn about yourself today?",
        "What are your hopes for tomorrow?",
        "What emotion are you feeling most strongly right now?",
        "Describe a conversation that impacted you today.",
        "What personal growth are you experiencing?",
        "What would you like to improve about yourself?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Length)];
    }
}

// Journal Management Class
public class JournalManager
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();
    private string _username;

    public JournalManager(string username)
    {
        _username = username;
    }

    public JournalEntry CreateNewEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine($"Prompt: {prompt}");

        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt
        };

        Console.Write("Your response: ");
        entry.Content = Console.ReadLine();

        // Mood input
        while (true)
        {
            Console.Write("How was your mood today? (1-10): ");
            if (int.TryParse(Console.ReadLine(), out int mood) && mood >= 1 && mood <= 10)
            {
                entry.Mood = mood;
                break;
            }
            Console.WriteLine("Please enter a valid mood between 1 and 10.");
        }

        // Tags input
        Console.Write("Add tags (comma-separated): ");
        string tagInput = Console.ReadLine();
        entry.Tags = tagInput.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(t => t.Trim())
                              .ToList();

        return entry;
    }

    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
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
            string json = JsonSerializer.Serialize(_entries,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText($"{_username}_{filename}", json);
            Console.WriteLine($"Journal saved successfully to {filename}");
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
            string json = File.ReadAllText($"{_username}_{filename}");
            _entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
            Console.WriteLine($"Journal loaded successfully from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e =>
            e.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Tags.Any(t => t.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.WriteLine("Matching Entries:");
        foreach (var entry in results)
        {
            entry.Display();
        }
    }
}

// Main Application Class
public class JournalApplication
{
    private UserRepository _userRepository;
    private JournalManager _journalManager;

    public JournalApplication()
    {
        _userRepository = new UserRepository();
    }

    public void Run()
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

            // Journal menu after successful login
            if (_journalManager != null)
            {
                RunJournalMenu();
            }
        }
    }

    private void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Personal Journal Application ---");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    private void Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = ReadPassword();

        if (_userRepository.ValidateUser(username, password))
        {
            _journalManager = new JournalManager(username);
            Console.WriteLine($"Welcome, {username}!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
            Console.ReadKey();
        }
    }

    private void Register()
    {
        Console.Write("Choose a username: ");
        string username = Console.ReadLine();
        Console.Write("Choose a password: ");
        string password = ReadPassword();

        if (_userRepository.RegisterUser(username, password))
        {
            Console.WriteLine("Registration successful!");
        }
        else
        {
            Console.WriteLine("Username already exists.");
        }
        Console.ReadKey();
    }

    private void RunJournalMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplayJournalMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var newEntry = _journalManager.CreateNewEntry();
                    _journalManager.AddEntry(newEntry);
                    break;
                case "2":
                    _journalManager.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    _journalManager.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    _journalManager.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Enter search keyword: ");
                    string keyword = Console.ReadLine();
                    _journalManager.SearchEntries(keyword);
                    break;
                case "6":
                    _journalManager = null;
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private void DisplayJournalMenu()
    {
        Console.WriteLine("--- Journal Menu ---");
        Console.WriteLine("1. New Entry");
        Console.WriteLine("2. View Entries");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Search Entries");
        Console.WriteLine("6. Logout");
        Console.Write("Choose an option: ");
    }

    // Secure password input method
    private string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    // Main entry point
    public static void Main()
    {
        var app = new JournalApplication();
        app.Run();
    }
}