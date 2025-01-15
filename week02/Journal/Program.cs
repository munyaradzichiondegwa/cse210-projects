
// Purpose: Create a journal entry class that has a prompt, response, and date.
//          The journal entry class should have a constructor that takes in a prompt and response.
//         The journal entry class should have a ToString method that returns the date, prompt, and response.
using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public JournalEntry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd");
        }

        public override string ToString()
        {
            return $"{Date} | {Prompt} | {Response}";
        }
    }

    public class Journal
    {
        private readonly List<JournalEntry> entries = new();
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
            entries.Add(new JournalEntry(prompt, response));
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
            using var writer = new StreamWriter(filename);
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }

        public void LoadFromFile(string filename)
        {
            entries.Clear();
            using var reader = new StreamReader(filename);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new JournalEntry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var journal = new Journal();
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("Journal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");
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
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}