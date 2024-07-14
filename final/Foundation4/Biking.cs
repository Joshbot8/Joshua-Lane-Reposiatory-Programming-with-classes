class Biking : Activity
{
    // Attributes
    private double _speed;

    // Constructor
    public Biking(string date, double minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    // Properties
    public double Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }

    // Implement abstract methods
    public override string GetSummary()
    {
        return $"{Date} Biking ({Minutes} min) - Distance: {Math.Round(CalculateDistance(),2)} miles, Speed: {Math.Round(CalculateSpeed(),2)} mph, Pace: {Math.Round(CalculatePace(),2)} min per mile";
    }

    public override double CalculateDistance()
    {
        return (Speed * Minutes) / 60;
    }

    public override double CalculateSpeed()
    {
        return Speed;
    }

    public override double CalculatePace()
    {
        return 60 / Speed;
    }
}