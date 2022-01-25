using System.Globalization;
using TratException.Entities;
using TratException.Entities.Exceptions;

var exit = 's';

while (exit != 'n'){
    try
    {
        Console.WriteLine("Enter account data: ");
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Holder: ");
        string holder = Console.ReadLine();

        Console.Write("Initial balance: ");
        double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Withdraw limit: ");
        double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Account account = new Account(number, holder, balance, withdrawLimit);

        Console.WriteLine();
        Console.Write("Enter amount for withdraw: ");
        double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        account.Withdraw(withdraw);
        Console.WriteLine("New Balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
    }
    catch (DomainException ex)
    {
        Console.WriteLine("Error! " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Unexpected Error! " + ex.Message);
    }
    Console.Write("Are you want to continue [s/n]?");
    exit = char.Parse(Console.ReadLine());
}