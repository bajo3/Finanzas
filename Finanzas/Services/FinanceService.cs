using Finanzas.Entities;
using Finanzas.Infrastructure;

namespace Finanzas.Services
{
    public class FinanceService
    {
        private List<Transaction> transactions = new List<Transaction>();
        public void AddTransaction(Transaction transaction)
        {
            this.transactions.Add(transaction); // siempre se agrega "this." cuando se referencian objetos contenidos en la misma clase.
        }

        public List<Transaction> GetTransactions() =>transactions;
        

        // estos dos metodos hacen exactamente lo mismo cambiando el Type sugiero utilizar un Enum para mandar el tipo
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

        public void AddTransaction(DateTime date, string description, decimal amount ,TransactionTypes type) // aca tenes una implementacion usando un enum. Se pasa por argumento en la function, notas algo raro?
        {
            //aca no se entiende por que es necesario desde un metodo llamar a otro que realiza la insercion del objeto, mete todo en el mismo.
            AddTransaction(new Transaction
            {
                Date = date,
                Description = description,
                Amount = amount,
                Type = type.ToEnumText()
            });
        }

        public decimal GetTotalIncome()
            => transactions.Where(t => t.Type == TransactionTypes.Ingreso.ToEnumText()).Sum(t => t.Amount);
        

        public decimal GetTotalExpenses()
            => transactions.Where(t => t.Type == TransactionTypes.Gasto.ToEnumText()).Sum(t => t.Amount);
      

        public decimal GetBalance()
            => GetTotalIncome() - GetTotalExpenses();
        
    }
}
