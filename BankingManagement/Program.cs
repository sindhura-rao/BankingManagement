// See https://aka.ms/new-console-template for more information
using BankingManagement;
using Classes;
var account = new BankAccount("<sindhu>", 2000);
var interestEarningAccount = new InterestEarningAccount("Sindhu2", 2000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

var account2 = new BankAccount("<somu>", 1000);
Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance.");


Console.WriteLine($"Sindhu balance {account.Balance}");
Console.WriteLine($"somu balance {account2.Balance}");
Console.WriteLine(account.GetAccountHistory());
Console.WriteLine(account2.GetAccountHistory());

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");

account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
 account2.MakeDeposit(200, DateTime.Now, "cash back");
Console.WriteLine($"Sindhu balance {account.Balance}");
Console.WriteLine($"somu balance {account2.Balance}");


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





