using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

//Creativity: my program excedes the requirements by working with a library of scriptures rather than a single one. it is randomly selected by a number generator.

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

// Main program class
class Program
{
    static void Main(string[] args)
    {
        try
        {
            ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
            Scripture scripture = library.GetRandomScripture();

            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);
                Console.Clear();
                Console.WriteLine(scripture);

                if (scripture.AllWordsHidden())
                {
                    break;
                }

                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
