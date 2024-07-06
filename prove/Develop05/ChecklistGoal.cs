public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;


    public int TargetCount
    {
        get { return _targetCount; }
        private set { _targetCount = value; }
    }


    public int CurrentCount
    {
        get { return _currentCount; }
        set { _currentCount = value; }
    }


    public int BonusPoints
    {
        get { return _bonusPoints; }
        private set { _bonusPoints = value; }
    }


    public ChecklistGoal(string title, string description, int points, int targetCount, int bonusPoints)
        : base(title, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
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