using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// Class to represent the entire scripture including its reference and text
public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<Word> Words;
    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        var wordsToHide = Words.Where(word => !word.IsHidden).OrderBy(_ => random.Next()).Take(count);
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(' ', Words)}";
    }
}