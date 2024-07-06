using System;
using System.Collections.Generic;
using System.IO;




//Improvement: Implements a leveling system to improve the fun aspect to the quest.


public class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _totalPoints = 0;
    static int _level = 1;
    static int _pointsToNextLevel = 1000;


    static void Main(string[] args)
    {
        DisplayMenu();
    }


    static void DisplayMenu()
    {
        while (true)
        {
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
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordGoalCompletion();
                    break;
                case "6":
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
        foreach (var goal in _goals)
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
                _goals.Add(new SimpleGoal(title, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(title, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(title, description, points, targetCount, bonusPoints));
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


        foreach (var goal in _goals)
        {
            if (goal.Title == title)
            {
                goal.Complete();
                _totalPoints += goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
                {
                    _totalPoints += checklistGoal.BonusPoints;
                }
                CheckLevelUp();
                break;
            }
        }
    }


    static void DisplayTotalPoints()
    {
        Console.WriteLine($"\nTotal points: {_totalPoints}");
        Console.WriteLine($"Current level: {_level}");
        Console.WriteLine($"Points to next level: {_pointsToNextLevel - _totalPoints}");
    }


    static void CheckLevelUp()
    {
        if (_totalPoints >= _pointsToNextLevel)
        {
            _level++;
            _totalPoints -= _pointsToNextLevel;
            _pointsToNextLevel += 1000;  // Increase the threshold for the next level
            Console.WriteLine($"Congratulations! You leveled up to level {_level}.");
        }
    }


    static void SaveGoals()
    {
        Console.WriteLine("Where would you like to save?");
        string fileName = Console.ReadLine();


        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_totalPoints);
            writer.WriteLine(_level);
            writer.WriteLine(_pointsToNextLevel);
            foreach (var goal in _goals)
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
        Console.WriteLine("What is the save file you would like to load?");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
        {
            _goals.Clear(); // Clear existing goals before loading new ones


            using (StreamReader reader = new StreamReader(fileName))
            {
                _totalPoints = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _pointsToNextLevel = int.Parse(reader.ReadLine());
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
                        _goals.Add(new SimpleGoal(title, description, points) { IsCompleted = isCompleted });
                    }
                    else if (type == nameof(EternalGoal))
                    {
                        _goals.Add(new EternalGoal(title, description, points));
                    }
                    else if (type == nameof(ChecklistGoal))
                    {
                        string checklistLine = reader.ReadLine();
                        var checklistParts = checklistLine.Split('|');
                        int targetCount = int.Parse(checklistParts[0]);
                        int currentCount = int.Parse(checklistParts[1]);
                        int bonusPoints = int.Parse(checklistParts[2]);
                        _goals.Add(new ChecklistGoal(title, description, points, targetCount, bonusPoints)
                        {
                            CurrentCount = currentCount,
                            IsCompleted = isCompleted
                        });
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Save file not found.");
        }
    }
}
