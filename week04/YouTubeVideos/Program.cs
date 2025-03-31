// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress1 = new Address("123 Main St", "Provo", "UT", "USA");
        Address nonUsaAddress1 = new Address("456 International Blvd", "London", "", "UK");
        Address usaAddress2 = new Address("789 Pine Ave", "New York", "NY", "USA");

        // Create customers
        Customer customer1 = new Customer("John Doe", usaAddress1);
        Customer customer2 = new Customer("Jane Smith", nonUsaAddress1);
        Customer customer3 = new Customer("Peter Jones", usaAddress2);

        // Create products
        Product product1 = new Product("Laptop", "LAP-001", 1200.00, 1);
        Product product2 = new Product("Mouse", "MOU-002", 25.00, 2);
        Product product3 = new Product("Keyboard", "KEY-003", 75.00, 1);
        Product product4 = new Product("Monitor", "MON-004", 300.00, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product1);

        Order order3 = new Order(customer3);
        order3.AddProduct(product2);
        order3.AddProduct(product4);

        // Display order 1 information
        Console.WriteLine($"--- Order 1 for {order1.Customer.Name} ---");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");
        Console.WriteLine();

        // Display order 2 information
        Console.WriteLine($"--- Order 2 for {order2.Customer.Name} ---");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
        Console.WriteLine();

        // Display order 3 information
        Console.WriteLine($"--- Order 3 for {order3.Customer.Name} ---");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order3.CalculateTotalCost()}");
        Console.WriteLine();
    }
}