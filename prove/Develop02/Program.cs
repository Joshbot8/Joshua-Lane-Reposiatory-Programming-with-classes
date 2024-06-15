using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private static Random random = new Random();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        entries.Add(new Entry(prompt, response));
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
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                string sanitizedPrompt = entry.Prompt.Replace("\"", "\"\"");
                string sanitizedResponse = entry.Response.Replace("\"", "\"\"");
                writer.WriteLine($"\"{entry.Date}\",\"{sanitizedPrompt}\",\"{sanitizedResponse}\"");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split(new[] { "\",\"" }, StringSplitOptions.None);
            if (parts.Length == 3)
            {
                string date = parts[0].Trim('\"');
                string prompt = parts[1].Replace("\"\"", "\"");
                string response = parts[2].Trim('\"').Replace("\"\"", "\"");
                entries.Add(new Entry(prompt, response) { Date = date });
            }
        }
    }

    public void SearchEntries(string keyword)
    {
        foreach (var entry in entries)
        {
            if (entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(entry);
            }
        }
    }
}

public class Program
{
    private static Journal journal = new Journal();

    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search the journal");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
