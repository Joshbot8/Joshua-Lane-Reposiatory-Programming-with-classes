using System;

class Program
{
    static void Main(string[] args)
    {
        //placeholder code
        Console.WriteLine("Hello Foundation4 World!");
    }
}

class Activity
{
    // Attributes
    private string _date;
    private double _minutes;
    // Constructor
    public Activity(string date, double minutes)
    {
        _date = date ;
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
    
}

class Running
{
    // Attributes
    private double _distance;
    // Constructor
    public Running(double distance)
    {
        _distance = distance;
    }
    // Properties
    public double Distance
    {
        get { return _distance; }
        private set { _distance = value; }
    }
}

class Biking
{
    // Attributes
    private double _speed;
    // Constructor
    public Biking ( double speed)
    {
        _speed = speed;
    }
    // Properties
    public double Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }
}

class Swimming
{
    // Attributes
    private int _laps;

    // Constructor
    public Swimming(int laps)
    {
        _laps = laps;
    }
    //Properties
    public int Laps
    {
        get { return _laps; }
        private set { _laps = value; }
    }
}