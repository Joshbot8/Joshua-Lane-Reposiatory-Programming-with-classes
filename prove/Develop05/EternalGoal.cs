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
