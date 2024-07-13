class Customer
{
    // Attributes
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public void PrintNameAndAddress()
    {
        Console.WriteLine(_name);
        _address.DisplayAddress();
        Console.WriteLine("\n");
    }

    // Properties
    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public Address Address
    {
        get { return _address; }
    }

    // Methods
    public bool IsCustomerInUSA()
    {
        return _address.AddressInUSA();
    }
}