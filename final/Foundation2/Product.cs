class Product
{
    // Attributes
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    // Properties
    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }
    public string Id
    {
        get { return _id; }
        private set { _id = value; }
    }
    public double Price
    {
        get { return _price; }
        private set { _price = value; }
    }
    public int Quantity
    {
        get { return _quantity; }
        private set { _quantity = value; }
    }

    // Methods
    public double CalculateCost()
    {
        return _quantity * _price;
    }
}