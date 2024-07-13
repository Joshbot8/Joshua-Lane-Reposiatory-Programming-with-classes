using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create two orders with 2 products in each order
        Address address1 = new("123 Elm Street", "Smalltown", "ST", "USA");
        Address address2 = new("456 Oak Avenue", "Bigtown", "BT", "Canada");

        Customer customer1 = new("Alice Johnson", address1);
        Customer customer2 = new("Bob Smith", address2);

        Product product1 = new("Widget", "001", 10.99, 5);
        Product product2 = new("Gadget", "002", 15.99, 3);
        Product product3 = new("Thingamajig", "003", 7.99, 10);
        Product product4 = new("Doodad", "004", 3.99, 20);

        Order order1 = new(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine("Order 1:");
        order1.DisplayOrderDetails();

        Console.WriteLine("\nOrder 2:");
        order2.DisplayOrderDetails();
    }
}
