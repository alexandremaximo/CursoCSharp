using System.Globalization;
using ClassMethAbstract.Entities;

List<TaxPayer> list = new List<TaxPayer>();

Console.Write("Enter the number of tax payers: ");
int payers = int.Parse(Console.ReadLine());

for (int i = 1; i <= payers; i++)
{
    Console.WriteLine($"Tax payer #{i} data:");

    Console.Write("Individual or company (i/c)? ");
    char type = char.Parse(Console.ReadLine());

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Anual income: ");
    double income = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

    if(type == 'i')
    {
        Console.Write("Health expenditures: ");
        double hExpend = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        list.Add(new Individual(name, income, hExpend));
    }
    else
    {
        Console.Write("Number of employees: ");
        int employees = int.Parse(Console.ReadLine());
        list.Add(new Company(name, income, employees));
    }    
}

double sum = 0.0;
Console.WriteLine();
Console.WriteLine("TAXES PAID:");
foreach (TaxPayer taxPayer in list)
{
    Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
    sum += taxPayer.Tax();
}

Console.WriteLine();
Console.WriteLine("TOTAL TAXES: $ "+ sum.ToString("F2",CultureInfo.InvariantCulture));