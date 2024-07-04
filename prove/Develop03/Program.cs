using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

//Creativity: my program excedes the requirements by working with a library of scriptures rather than a single one. it is randomly selected by a number generator.



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
