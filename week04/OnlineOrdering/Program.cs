using System;

class Program
{
    static void Main(string[] args)
    {
        Address firstAddress = new Address("125 Maple Street", "Springfield", "IL", "USA");
        Address secondAddress = new Address("48 King's Road", "London", "SW3 4UD", "United Kingdom");
        Address thirdAddress = new Address("902 Oceanview Avenue", "Sydney", "NSW", "Australia");
        Customer firstCustomer = new Customer("Michael Thompson", firstAddress);
        Customer secondCustomer = new Customer("Emily Carter", secondAddress);
        Customer thirdCustomer = new Customer("Liam Anderson", thirdAddress);
        Order firstOrder = new Order(firstCustomer);
        Order secondOrder = new Order(secondCustomer);
        Order thirdOrder = new Order(thirdCustomer);

        Product wirelessMouse = new Product("Wireless Mouse", "P-001", 25.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", "P-002", 79.50, 1);
        Product usbCable = new Product("USB-C Cable", "P-003", 9.99, 3);
        firstOrder.AddProduct(wirelessMouse);
        firstOrder.AddProduct(keyboard);
        firstOrder.AddProduct(usbCable);

        Product headphones = new Product("Bluetooth Headphones", "P-004", 59.90, 1);
        Product smartphoneCase = new Product("Smartphone Case", "P-005", 15.00, 2);
        secondOrder.AddProduct(headphones);
        secondOrder.AddProduct(smartphoneCase);

        Product shoes = new Product("Running Shoes", "P-006", 120.00, 1);
        Product tshirt = new Product("Sports T-Shirt", "P-007", 29.99, 2);
        Product waterBottle = new Product("Water Bottle", "P-008", 12.50, 1);
        thirdOrder.AddProduct(shoes);
        thirdOrder.AddProduct(tshirt);
        thirdOrder.AddProduct(waterBottle);

        Console.WriteLine("--- Order #1 ---");
        Console.WriteLine();
        Console.WriteLine(firstOrder.GetDisplayShippingLabel());
        Console.WriteLine(firstOrder.GetDisplayPackingLabel());
        Console.WriteLine($"Total: ${firstOrder.GetOrderTotal():F2}");
        Console.WriteLine();

        Console.WriteLine("--- Order #2 ---");
        Console.WriteLine();
        Console.WriteLine(secondOrder.GetDisplayShippingLabel());
        Console.WriteLine(secondOrder.GetDisplayPackingLabel());
        Console.WriteLine($"Total: ${secondOrder.GetOrderTotal():F2}");
        Console.WriteLine();

        Console.WriteLine("--- Order #3 ---");
        Console.WriteLine();
        Console.WriteLine(thirdOrder.GetDisplayShippingLabel());
        Console.WriteLine(thirdOrder.GetDisplayPackingLabel());
        Console.WriteLine($"Total: ${thirdOrder.GetOrderTotal():F2}");
        Console.WriteLine();
    }
}