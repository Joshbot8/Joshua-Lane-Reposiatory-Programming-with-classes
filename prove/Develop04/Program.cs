using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

//Enhancement: We added another section so you can reflect on goals you would like to do for the year to improve yourself
public abstract class MindfulnessActivity
{
    protected int _duration;


    public MindfulnessActivity()
    {
       
    }


    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {this.GetType().Name} Activity\n");
        Console.WriteLine(Description());
        SetDuration();
        Console.Clear();
        PrepareToBegin();
        PerformActivity();
        End();
    }


    public abstract string Description();


    public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }


    public void PrepareToBegin()
    {
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(5);
    }


    public abstract void PerformActivity();


    public void End()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You completed the {this.GetType().Name} Activity for {_duration} seconds.");
        ShowAnimation(5);
    }


    public void ShowAnimation(int duration)
    {
        char[] chars = { '|', '/', '-', '\\' };
        for (int i = 0; i < duration; i++)
        {
            foreach (char c in chars)
            {
                Console.Write(c + "\r");
                Thread.Sleep(250);
            }
        }
    }
}


public class Breathing : MindfulnessActivity
{
    public Breathing()  { }


    public override string Description()
    {
        return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.\n";
    }


    public override void PerformActivity()
    {
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }


    public void ShowCountdown(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}


public class Reflection : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };


    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };


    public Reflection()  { }


    public override string Description()
    {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n";
    }


    public override void PerformActivity()
    {
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);


        Console.Write("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();


        Console.Write("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("\nYou may begin in: \n");
        // Need to put in a wait counter here


        Console.Clear();


        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            string question = Questions[random.Next(Questions.Count)];
            Console.WriteLine(question);
            ShowAnimation(5);
        }
    }
}


public class Listing : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    public Listing()  { }


    public override string Description()
    {
        return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n";
    }


    public override void PerformActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        ShowAnimation(5);


        DateTime startTime = DateTime.Now;
        List<string> items = new List<string>();


        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }


        Console.WriteLine($"You listed {items.Count} items.");
    }
}

public class Goals : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "What are your spiritual goals?",
        "What are your physical goals?",
        "what are your mental goals?",
        "what are your spiritual goals?"
    };


    public Goals()  { }


    public override string Description()
    {
        return "This activity will help you reflect on goals you would like to implement for the year to better yourself.\n";
    }


    public override void PerformActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        ShowAnimation(5);


        DateTime startTime = DateTime.Now;
        List<string> items = new List<string>();


        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }


        Console.WriteLine($"You listed {items.Count} items.");
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Func<MindfulnessActivity>> activities = new Dictionary<string, Func<MindfulnessActivity>>
        {
            { "1", () => new Breathing() },
            { "2", () => new Reflection() },
            { "3", () => new Listing() },
            { "4", () => new Goals() }
            
        };




        while (true)
        {
            Console.Clear();
           
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Goals Activity");
            Console.WriteLine("  5. Quit");


            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();


            if (choice == "5")
            {
                break;
            }
            else if (activities.ContainsKey(choice))
            {
                var activity = activities[choice]();
                activity.Start();
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }
}







