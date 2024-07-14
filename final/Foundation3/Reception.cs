public class Reception : Event
{
    private string _email;

    // Constructor
    public Reception(string title, string description, string date, string time, Address address, string email)
        : base(title, description, date, time, address)
    {
        _email = email;
    }

    public string Email
    {
        get { return _email; }
        private set { _email = value; }
    }

    public override void GetFullDetails()
    {
        GetStandardDetails();
        Console.WriteLine("Email: " + _email + "\n");
    }

    public override void GetShortDescription()
    {
        Console.WriteLine("EventType: Reception" + "\nTitle: " + Title + "\nDate: " + Date);
    }
}