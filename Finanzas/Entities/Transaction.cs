namespace Finanzas.Entities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypes Type { get; set; }
    }

    public enum TransactionTypes
    {
        Ingreso,
        Gasto
    }
}
