using System;
using System.Collections.Generic;
using System.Linq;
using Finanzas.Entities;
using Finanzas.Infrastructure;

namespace Finanzas.Services
{
    public class FinanceService
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(DateTime date, string description, decimal amount, TransactionTypes type)
        {
            transactions.Add(new Transaction
            {
                Date = date,
                Description = description,
                Amount = amount,
                Type = type
            });
        }

        public List<Transaction> GetTransactions() => transactions;

        public decimal GetTotalIncome()
            => transactions.Where(t => t.Type == TransactionTypes.Ingreso).Sum(t => t.Amount);

        public decimal GetTotalExpenses()
            => transactions.Where(t => t.Type == TransactionTypes.Gasto).Sum(t => t.Amount);

        public decimal GetBalance()
            => GetTotalIncome() - GetTotalExpenses();
    }
}
