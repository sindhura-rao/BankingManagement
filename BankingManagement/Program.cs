// See https://aka.ms/new-console-template for more information
using Classes;
var account = new BankAccount("<sindhu>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

var account2 = new BankAccount("<somu>", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

Console.WriteLine($"Sindhu balance {account.Balance}");
Console.WriteLine($"somu balance {account2.Balance}");


account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine($"Sindhu {account.Balance}");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
BankAccount invalidAccount;

//Test that the initial balances must be positive.
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}

//Test for a negative balance.
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}





