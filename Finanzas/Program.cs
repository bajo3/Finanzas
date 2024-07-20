
using System;
using System.Collections.Generic;
using System.Linq;

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
        return transactions.Where(t => t.Type == "Ingreso").Sum(t => t.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return transactions.Where(t => t.Type == "Gasto").Sum(t => t.Amount);
    }

    public decimal GetBalance()
    {
        return GetTotalIncome() - GetTotalExpenses();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        FinanceManager manager = new FinanceManager();
        while (true)
        {
            Console.WriteLine("1. Registrar Ingreso");
            Console.WriteLine("2. Registrar Gasto");
            Console.WriteLine("3. Ver Reportes");
            Console.WriteLine("4. Salir");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RegisterIncome(manager);
                    break;
                case "2":
                    RegisterExpense(manager);
                    break;
                case "3":
                    ShowReports(manager);
                    break;
                case "4":
                    return;
            }
        }
    }

    static void RegisterIncome(FinanceManager manager)
    {
        Console.WriteLine("Fecha (yyyy-mm-dd):");
        var date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Descripción:");
        var description = Console.ReadLine();
        Console.WriteLine("Monto:");
        var amount = decimal.Parse(Console.ReadLine());

        manager.AddIncome(date, description, amount);
    }

    static void RegisterExpense(FinanceManager manager)
    {
        Console.WriteLine("Fecha (yyyy-mm-dd):");
        var date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Descripción:");
        var description = Console.ReadLine();
        Console.WriteLine("Monto:");
        var amount = decimal.Parse(Console.ReadLine());

        manager.AddExpense(date, description, amount);
    }

    static void ShowReports(FinanceManager manager)
    {
        Console.WriteLine("Total Ingresos: " + manager.GetTotalIncome());
        Console.WriteLine("Total Gastos: " + manager.GetTotalExpenses());
        Console.WriteLine("Balance Actual: " + manager.GetBalance());
    }
}
