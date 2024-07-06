using System;
using System.Collections.Generic;
using System.IO;








public abstract class Goal
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }








    public Goal(string title, string description, int points)
    {
        Title = title;
        Description = description;
        Points = points;
        IsCompleted = false;
    }








    public abstract void Complete();
    public abstract void DisplayStatus();
}








public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points) { }








    public override void Complete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"{Title} completed! You earned {Points} points.");
        }
    }








    public override void DisplayStatus()
    {
        Console.WriteLine($"{(IsCompleted ? "[X]" : "[ ]")} {Title} - {Description} - {Points} points");
    }
}








public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points) { }








    public override void Complete()
    {
        Console.WriteLine($"{Title} recorded! You earned {Points} points.");
    }








    public override void DisplayStatus()
    {
        Console.WriteLine($"[∞] {Title} - {Description} - {Points} points each time");
    }
}








public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }








    public ChecklistGoal(string title, string description, int points, int targetCount, int bonusPoints)
        : base(title, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }








    public override void Complete()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Console.WriteLine($"{Title} completed {CurrentCount}/{TargetCount} times! You earned {Points} points.");
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Congratulations! You completed {Title} and earned a bonus of {BonusPoints} points.");
            }
        }
    }








    public override void DisplayStatus()
    {
        Console.WriteLine($"{(IsCompleted ? "[X]" : "[ ]")} {Title} - {Description} - {Points} points - Completed {CurrentCount}/{TargetCount} times");
    }
}








public class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;
    static int level = 1;
    static int pointsToNextLevel = 1000;








    static void Main(string[] args)
    {
        DisplayMenu();
    }








    static void DisplayMenu()
    {
        while (true)
        {
            //Console.WriteLine("\nEternal Quest Program");
            //Console.WriteLine("1. Display Goals");
            //Console.WriteLine("2. Add Goal");
            //Console.WriteLine("3. Record Goal Completion");
            //Console.WriteLine("4. Display Score");
            //Console.WriteLine("5. Save and Exit");








            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Goal Event");
            Console.WriteLine("6. Quit");








            string choice = Console.ReadLine();








            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    DisplayGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;








                //TBD-Function goals needs be created
                case "4":
                    LoadGoals();
                    break;
               
                case "5":
                    RecordGoalCompletion();
                    break;
                //TBD-Function Exit needs be created
                case "6":
                    //Exit()
                    return;
               
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }


            DisplayTotalPoints();
        }
    }








    static void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in goals)
        {
            goal.DisplayStatus();
        }
    }








    static void AddGoal()
    {
        Console.WriteLine("\nSelect goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");








        string choice = Console.ReadLine();








        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());








        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(title, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(title, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(title, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
    }








    static void RecordGoalCompletion()
    {
        Console.Write("Enter the title of the goal you completed: ");
        string title = Console.ReadLine();








        foreach (var goal in goals)
        {
            if (goal.Title == title)
            {
                goal.Complete();
                totalPoints += goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
                {
                    totalPoints += checklistGoal.BonusPoints;
                }
                CheckLevelUp();
                break;
            }
        }
    }








    static void DisplayTotalPoints()
    {
        Console.WriteLine($"\nTotal points: {totalPoints}");
        Console.WriteLine($"Current level: {level}");
        Console.WriteLine($"Points to next level: {pointsToNextLevel - totalPoints}");
    }








    static void CheckLevelUp()
    {
        if (totalPoints >= pointsToNextLevel)
        {
            level++;
            totalPoints -= pointsToNextLevel;
            pointsToNextLevel += 1000;  // Increase the threshold for the next level
            Console.WriteLine($"Congratulations! You leveled up to level {level}.");
        }
    }








    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalPoints);
            writer.WriteLine(level);
            writer.WriteLine(pointsToNextLevel);
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Title}|{goal.Description}|{goal.Points}|{goal.IsCompleted}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.TargetCount}|{checklistGoal.CurrentCount}|{checklistGoal.BonusPoints}");
                }
            }
        }
    }








    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                totalPoints = int.Parse(reader.ReadLine());
                level = int.Parse(reader.ReadLine());
                pointsToNextLevel = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    string type = parts[0];
                    string title = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isCompleted = bool.Parse(parts[4]);




                    if (type == nameof(SimpleGoal))
                    {
                        goals.Add(new SimpleGoal(title, description, points) { IsCompleted = isCompleted });
                    }
                    else if (type == nameof(EternalGoal))
                    {
                        goals.Add(new EternalGoal(title, description, points));
                    }
                    else if (type == nameof(ChecklistGoal))
                    {
                        string checklistLine;
                        checklistLine = reader.ReadLine();


                        var checkListParts = checklistLine.Split('|');
                        int targetCount = int.Parse(checkListParts[0]);
                        int currentCount = int.Parse(checkListParts[1]);
                        int bonusPoints = int.Parse(checkListParts[2]);
                        goals.Add(new ChecklistGoal(title, description, points, targetCount, bonusPoints)
                        {
                            CurrentCount = currentCount,
                            IsCompleted = isCompleted
                        });
                    }
                }
            }
        }
    }
}













