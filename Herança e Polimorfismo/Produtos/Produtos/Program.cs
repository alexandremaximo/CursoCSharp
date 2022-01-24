using System.Globalization;
using System.Collections.Generic;
using Produtos.Entities;

List<Product> list = new List<Product>();

Console.Write("Enter the number of products: ");
int numProd = int.Parse(Console.ReadLine());

for (int i = 1; i <= numProd; i++)
{
    Console.WriteLine($"Product #{i} data:");

    Console.Write("Common, used or imported (c/u/i)? ");
    char tpProduct = char.Parse(Console.ReadLine());

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Price: ");
    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    if (tpProduct == 'i')
    {
        Console.Write("Customs fee: ");
        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        list.Add(new ImportedProduct(name, price, customsFee));
    }
    else if (tpProduct == 'u')
    {
        Console.Write("Manufacture date (DD/MM/YYYY): ");
        DateOnly manDate = DateOnly.Parse(Console.ReadLine());
        list.Add(new UsedProduct(name, price, manDate));
    }
    else
    {
        list.Add(new Product(name, price));
    }

}
Console.WriteLine();
Console.WriteLine("PRICE TAGS:");
foreach (Product product in list)
{
    Console.WriteLine(product.priceTag());
}