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