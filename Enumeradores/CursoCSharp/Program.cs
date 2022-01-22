using CursoCSharp.Entities;
using CursoCSharp.Entities.Enum;
using System.Globalization;

Console.WriteLine("Enter cliente data:");

Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Email: ");
string email = Console.ReadLine();

Console.Write("Birth date (DD/MM/YYYY): ");
DateTime birthDate = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Enter order data: ");
Console.Write("Status: ");
OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

Client client = new Client(name, email, birthDate);
Order order = new Order(DateTime.Now, orderStatus, client);

Console.Write("How many items to this order? ");
int items = int.Parse(Console.ReadLine());

for (int i = 1; i <= items; i++)
{
    Console.WriteLine($"Enter #{i} item data:");

    Console.Write("Product name: ");
    string productName = Console.ReadLine();

    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Product product = new Product(productName, productPrice);

    Console.Write("Quantity: ");
    int productQuantity = int.Parse(Console.ReadLine());

    OrderItem orderItem = new OrderItem(productQuantity, product.price, product);
    order.AddItem(orderItem);
}

Console.WriteLine();
Console.WriteLine("ORDER SUMMARY:");
Console.WriteLine(order);


