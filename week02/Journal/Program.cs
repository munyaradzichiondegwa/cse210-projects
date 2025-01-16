// path: week02/Journal/Program.cs
// Create Journal Program
// Create Entry for Journal

using System;

namespace Journal
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response) => (Date, Prompt, Response) = (date, prompt, response);
        public string GetEntryAsString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }

        public string GetEntryAsCSV()
        {
            return $"{Date}~|~{Prompt}~|~{Response}";
        }
    }

    // Create Journal PromptGenerator

    public class PromptGenerator
    {
        private readonly List<string> _prompts;
        private readonly Random _random;

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

    // Create Journal class

    public class Journal
    {
    private readonly List<Entry> _entries;
    private readonly PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

        public void WriteNewEntry()
        {
            string prompt = _promptGenerator.GetRandomPrompt();
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("> ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToShortDateString();

            Entry entry = new Entry(date, prompt, response);
            _entries.Add(entry);
        }

        public void DisplayJournal()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nNo entries to display.");
                return;
            }

            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in _entries)
            {
                Console.WriteLine("\n" + entry.GetEntryAsString());
            }
        }

        public void SaveToFile()
        {
            Console.Write("\nEnter filename to save: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine(entry.GetEntryAsCSV());
                    }
                }
                Console.WriteLine("Journal saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            Console.Write("\nEnter filename to load: ");
            string filename = Console.ReadLine();

            try
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                
                foreach (string line in lines)
                {
                    string[] parts = line.Split("~|~");
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry(parts[0], parts[1], parts[2]);
                        _entries.Add(entry);
                    }
                }
                Console.WriteLine("Journal loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}

// Create Program class

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
        Journal.Journal journal = new Journal.Journal();
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }
}
    