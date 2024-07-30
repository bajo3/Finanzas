using System;
using Finanzas.Entities;
using Finanzas.Services;

namespace Finanzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FinanceService manager = new FinanceService();
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

        static void RegisterIncome(FinanceService manager)
        {
            Console.WriteLine(CustomMessages.DateInput);
            var date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(CustomMessages.DescriptionInput);
            var description = Console.ReadLine();
            Console.WriteLine(CustomMessages.AmountInput);
            var amount = decimal.Parse(Console.ReadLine());

            manager.AddTransaction(date, description, amount, TransactionTypes.Ingreso);
        }

        static void RegisterExpense(FinanceService manager)
        {
            Console.WriteLine(CustomMessages.DateInput);
            var date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(CustomMessages.DescriptionInput);
            var description = Console.ReadLine();
            Console.WriteLine(CustomMessages.AmountInput);
            var amount = decimal.Parse(Console.ReadLine());

            manager.AddTransaction(date, description, amount, TransactionTypes.Gasto);
        }

        static void ShowReports(FinanceService manager)
        {
            Console.WriteLine("Total Ingresos: " + manager.GetTotalIncome());
            Console.WriteLine("Total Gastos: " + manager.GetTotalExpenses());
            Console.WriteLine("Balance Actual: " + manager.GetBalance());
        }
    }
}
