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