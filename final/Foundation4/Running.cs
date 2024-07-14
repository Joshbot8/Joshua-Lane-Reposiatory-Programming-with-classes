class Running : Activity
{
    // Attributes
    private double _distance;

    // Constructor
    public Running(string date, double minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    // Properties
    public double Distance
    {
        get { return _distance; }
        private set { _distance = value; }
    }

    // Implement abstract methods
    public override string GetSummary()
    {
        return $"{Date} Running ({Minutes} min) - Distance: {Math.Round(CalculateDistance(),2)} miles, Speed: {Math.Round(CalculateSpeed(),2)} mph, Pace: {Math.Round(CalculatePace(),2)} min per mile";
    }

    public override double CalculateDistance()
    {
        return Distance;
    }

    public override double CalculateSpeed()
    {
        return (Distance / Minutes) * 60;
    }

    public override double CalculatePace()
    {
        return Minutes / Distance;
    }
}