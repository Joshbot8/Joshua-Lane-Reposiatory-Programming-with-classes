using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an address
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("123 Avengers Tower St", "NY", "NY", "USA");
        Address address3 = new Address("123 T'Challa St", "Wakanda Town", "Wakanda State", "Wakanda");

        // Create events
        Lecture lecture = new Lecture("Tech Talk", "A talk on AI advancements", "07/20/2024", "10:00 AM", address1, "Dr. John Smith", 100);
        Reception reception = new Reception("Networking Event", "An opportunity to network with professionals", "07/21/2024", "6:00 PM", address2, "TonyStark@StarkEnterprise.com");
        Outdoor outdoor = new Outdoor("Picnic", "A fun outdoor picnic in Wakanda", "07/22/2024", "12:00 PM", address3, "Sunny");
        
        //GetStandardTest
        
        // Display details for each event
        Console.WriteLine("\nStandard Details: ");
        lecture.GetStandardDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nLecture Full Details:");
        lecture.GetFullDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nLecture Short Description:");
        lecture.GetShortDescription();
        Console.WriteLine("\n_______________________________");
        
        Console.WriteLine("\nStandard Details: ");
        reception.GetStandardDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nReception Full Details:");
        reception.GetFullDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nReception Short Description:");
        reception.GetShortDescription();
        Console.WriteLine("\n_______________________________");
        
        Console.WriteLine("\nStandard Details: ");
        outdoor.GetStandardDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nOutdoor Full Details:");
        outdoor.GetFullDetails();
        Console.WriteLine("\n_______________________________");
        Console.WriteLine("\nOutdoor Short Description:");
        outdoor.GetShortDescription();
        Console.WriteLine("\n_______________________________");
    }
}







