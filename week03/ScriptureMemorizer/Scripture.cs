using System;

using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();
        
        // Split text into words and create Word objects
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        var unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        
        int wordsToHide = Math.Min(numberToHide, unhiddenWords.Count);
        
        for (int i = 0; i < wordsToHide; i++)
        {
            if (unhiddenWords.Count > 0)
            {
                int index = _random.Next(unhiddenWords.Count);
                unhiddenWords[index].Hide();
                unhiddenWords.RemoveAt(index);
            }
        }
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public Reference GetReference()
    {
        return _reference;
    }
}