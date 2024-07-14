class Swimming : Activity
{
    // Attributes
    private int _laps;

    // Constructor
    public Swimming(string date, double minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Properties
    public int Laps
    {
        get { return _laps; }
        private set { _laps = value; }
    }

    // Implement abstract methods
    public override string GetSummary()
    {
        return $"{Date} Swimming ({Minutes} min) - Distance: {Math.Round(CalculateDistance(),2)} Miles, Speed: {Math.Round(CalculateSpeed(),2)} mph, Pace: {Math.Round(CalculatePace(),2)} min per mile";
    }

    public override double CalculateDistance()
    {
        return  Laps * 50 / 1000 * 0.62;
    }

    public override double CalculateSpeed()
    {
        return (CalculateDistance() / Minutes) * 60;
    }

    public override double CalculatePace()
    {
        return Minutes / CalculateDistance();
    }
}