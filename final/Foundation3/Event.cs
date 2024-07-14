public abstract class Event
{
    // Attributes
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    // Constructor
    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Properties
    public string Title
    {
        get { return _title; }
        private set { _title = value; }
    }
    public string Description
    {
        get { return _description; }
        private set { _description = value; }
    }
    public string Date
    {
        get { return _date; }
        private set { _date = value; }
    }
    public string Time
    {
        get { return _time; }
        private set { _time = value; }
    }
    public Address Address
    {
        get { return _address; }
    }

    public void GetStandardDetails()
    {
        Console.WriteLine("Title: " + _title + "\nDescription: " + _description + "\nDate: " + _date + " Time: " + _time + "\n");
        _address.DisplayAddress();
    }

    public abstract void GetShortDescription();
    public abstract void GetFullDetails();
}