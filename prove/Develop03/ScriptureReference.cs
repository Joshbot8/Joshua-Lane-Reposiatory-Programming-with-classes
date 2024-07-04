using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// Class to represent the scripture reference
public class ScriptureReference
{
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndChapter { get; private set; }
    public int? EndVerse { get; private set; }

    public ScriptureReference(string reference)
    {
        var parts = reference.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
        Book = parts[0];
        StartChapter = int.Parse(parts[1]);
        StartVerse = int.Parse(parts[2]);

        if (parts.Length > 3)
        {
            if (parts.Length == 4)
            {
                EndVerse = int.Parse(parts[3]);
            }
            else
            {
                EndChapter = int.Parse(parts[3]);
                EndVerse = int.Parse(parts[4]);
            }
        }
    }

    public override string ToString()
    {
        if (EndChapter.HasValue)
        {
            return $"{Book} {StartChapter}:{StartVerse}-{EndChapter}:{EndVerse}";
        }
        else if (EndVerse.HasValue)
        {
            return $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {StartChapter}:{StartVerse}";
        }
    }
}