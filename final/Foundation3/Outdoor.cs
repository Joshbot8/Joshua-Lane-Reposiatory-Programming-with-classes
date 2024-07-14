public class Outdoor : Event
{
    private string _weather;

    public Outdoor(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public string Weather
    {
        get { return _weather; }
        private set { _weather = value; }
    }

    public override void GetFullDetails()
    {
        GetStandardDetails();
        Console.WriteLine("Weather: " + _weather + "\n");
    }

    public override void GetShortDescription()
    {
        Console.WriteLine("EventType: Outdoor" + "\nTitle: " + Title + "\nDate: " + Date);
    }
}