using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        Running running = new Running("Nov 2022", 30, 3.0);
        Biking biking = new Biking("Nov 2022", 45, 15.0);
        Swimming swimming = new Swimming("Nov 2022", 60, 30);

        // Display activity details
        Console.WriteLine(running.GetSummary());
        Console.WriteLine(biking.GetSummary());
        Console.WriteLine(swimming.GetSummary());
    }
}

abstract class Activity
{
    // Attributes
    private string _date;
    private double _minutes;

    // Constructor
    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Properties
    public string Date
    {
        get { return _date; }
        private set { _date = value; }
    }

    public double Minutes
    {
        get { return _minutes; }
        private set { _minutes = value; }
    }

    // Abstract method to be implemented by derived classes
    public abstract string GetSummary();
    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();
}

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
        return $"{Date} Running ({Minutes} min) - Distance: {CalculateDistance()} miles, Speed: {CalculateSpeed()} mph, Pace: {CalculatePace()} min per mile";
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
        return $"{Date} Biking ({Minutes} min) - Distance: {CalculateDistance()} miles, Speed: {CalculateSpeed()} mph, Pace: {CalculatePace()} min per mile";
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
        return $"{Date} Swimming ({Minutes} min) - Distance: {CalculateDistance()} km, Speed: {CalculateSpeed()} kph, Pace: {CalculatePace()} min per km";
    }

    public override double CalculateDistance()
    {
        return Laps * 50 / 1000.0;
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
