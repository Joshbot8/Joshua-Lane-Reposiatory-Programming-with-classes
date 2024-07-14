public class Address
{
    // Attributes
    private string _streetAndNumber;
    private string _city;
    private string _stateProv;
    private string _country;

    // Constructor
    public Address(string street, string city, string stateProv, string country)
    {
        _streetAndNumber = street;
        _city = city;
        _stateProv = stateProv;
        _country = country;
    }

    public bool AddressInUSA()
    {
        return _country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{_streetAndNumber}\n{_city}, {_stateProv}, {_country}";
    }

    public void DisplayAddress()
    {
        Console.WriteLine(GetFullAddress());
    }

    // Properties
    public string Street
    {
        get { return _streetAndNumber; }
        private set { _streetAndNumber = value; }
    }
    public string City
    {
        get { return _city; }
        private set { _city = value; }
    }
    public string StateProv
    {
        get { return _stateProv; }
        private set { _stateProv = value; }
    }
    public string Country
    {
        get { return _country; }
        private set { _country = value; }
    }
}