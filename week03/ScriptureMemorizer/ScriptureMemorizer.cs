using System;

class ScriptureMemorizer
{
    private Scripture _scripture;
    private Random _random;

    public ScriptureMemorizer(Scripture scripture)
    {
        _scripture = scripture;
        _random = new Random();
    }

    public void Start()
    {
        while (!_scripture.IsCompletelyHidden())
        {
            DisplayScripture();
            
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            HideWords();
            Console.Clear();
        }

        // Final display
        DisplayScripture();
        Console.WriteLine("\nCongratulations! You've memorized the scripture.");
    }

    private void DisplayScripture()
    {
        Console.WriteLine(_scripture.GetReference().GetDisplayText());
        Console.WriteLine(_scripture.GetDisplayText());
    }

    private void HideWords()
    {
        // Hide 2-3 words each time
        int wordsToHide = _random.Next(2, 4);
        _scripture.HideRandomWords(wordsToHide);
    }
}