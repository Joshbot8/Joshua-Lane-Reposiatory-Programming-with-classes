class Order
{
    // Attributes
    private List<Product> _productList = new List<Product>();
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
    }

    // Methods
    public void AddProduct(Product product)
    {
        _productList.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in _productList)
        {
            totalCost += product.CalculateCost();
        }
        if (_customer.IsCustomerInUSA() == true)
        {
            totalCost+= 5.00;
        }

        else
        {
            totalCost+= 35.00;
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n====================\n";
        foreach (var product in _productList)
        {
            label += $"Product: {product.Name}, ID: {product.Id}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n=====================\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"Total Price: ${CalculateTotalCost():F2}");
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine(GetShippingLabel());
    }
}