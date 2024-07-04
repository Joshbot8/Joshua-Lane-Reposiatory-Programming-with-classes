using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// Class to load and manage a library of scriptures
public class ScriptureLibrary
{
    private List<Scripture> Scriptures;

    public ScriptureLibrary(string filePath)
    {
        Scriptures = new List<Scripture>();
        LoadScriptures(filePath);
    }

    private void LoadScriptures(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i += 2)
            {
                string reference = lines[i];
                string text = lines[i + 1];
                Scriptures.Add(new Scripture(reference, text));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures: {ex.Message}");
        }
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(Scriptures.Count);
        return Scriptures[index];
    }
}