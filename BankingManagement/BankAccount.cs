using System.ComponentModel.DataAnnotations;

namespace Classes;

public class BankAccount
{
    private static int s_accountNumberSeed = 1234567890;
    private List<Transaction> _allTransactions = new List<Transaction>();
    private readonly decimal _maxWithdrawal = 0;
    public static DateTime Now { get; }
   // public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
    public BankAccount(string name, decimal initialBalance, decimal maxWithdrawal)
    {

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        _maxWithdrawal = maxWithdrawal;

        Owner = name;
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }
    

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <=0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }

        if (amount > _maxWithdrawal)
        {
            throw new InvalidOperationException("withdrawal limit exceeded");
        }
        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
        amount = Balance-amount;
        
    }
    

    public virtual void PerformMonthEndTransactions() { }

    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance = balance + item.Amount;
                //balance += item.Amount; same as above
            }

            return balance;
        }
    }


    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

   // public virtual void PerformMonthEndTransactions() { }

}












