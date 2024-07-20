using static System.Runtime.InteropServices.JavaScript.JSType;

public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; }

}

public class FinanceManager
{
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return transactions;
    }
    public void AddIncome(DateTime date, string description, decimal amount)
    {
        AddTransaction(new Transaction
        {
            Date = date,
            Description = description,
            Amount = amount,
            Type = "Ingreso"
        });
    }

    public void AddExpense(DateTime date, string description, decimal amount)
    {
        AddTransaction(new Transaction
        {
            Date = date,
            Description = description,
            Amount = amount,
            Type = "Gasto"
        });
    }

    public decimal GetTotalIncome()
    {
        return Transaction.Where(t => t.Type == "Ingreso").Sum(t => t.Amount);

    }

}


