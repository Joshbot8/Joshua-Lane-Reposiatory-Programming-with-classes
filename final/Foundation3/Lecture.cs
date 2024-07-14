public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    // Constructor
    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string Speaker
    {
        get { return _speaker; }
        private set { _speaker = value; }
    }
    public int Capacity
    {
        get { return _capacity; }
        private set { _capacity = value; }
    }

    public override void GetFullDetails()
    {
        GetStandardDetails();
        Console.WriteLine("\nSpeaker: " + _speaker + "\nCapacity: " + _capacity + "\n");
    }

    public override void GetShortDescription()
    {
        Console.WriteLine("\nEventType: Lecture" + "\nTitle: " + Title + "\nDate: " + Date + "\n");
    }
}