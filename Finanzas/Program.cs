﻿
using Finanzas.Entities;
using Finanzas.Services;

public class Program
{
    public static void Main(string[] args)
    {

        // implementa esto en un servicio de compra de coches. Para esto vas a tener que generar un objeto coche. y generar instancias de un coche
        //listarlos y poder seleccionarlos 
        FinanceService manager = new();
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

    //este metodo Register income, tiene que estar dentro de la clase FinanceService por que es responsabilidad de esta esta tarea.
    //lo mismo con las otras que requieren ese Service.
    static void RegisterIncome(FinanceService manager)
    {
        // aca sujiero que en el metodo reciba directamente una Transaction. Y que internamente la guarde. la logica de lo que SE MUESTRA
        //en la pantalla pertenece ,en este caso a la clase program pero la que realiza el guardado pertenece a la capa de SERVICIO de Finance. 
        Console.WriteLine("Fecha (yyyy-mm-dd):");
        var date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Descripción:");
        var description = Console.ReadLine();
        Console.WriteLine("Monto:");
        var amount = decimal.Parse(Console.ReadLine());

        manager.AddTransaction(date, description, amount, TransactionTypes.Gasto);
    }

    static void RegisterExpense(FinanceService manager)
    {
        // TODOS los mensajes que estan dentro de los console.Write linne genera una clase estatica que retorne los textos. Es mas eficiente 
        //y podes reutilizar los mensajes repetidos. 
        /////
        ///public static class CustomMessages()
        ///{
        ///public static string DateInput => "Fecha (yyyy-mm-dd):"
        ///...
        ///...
        ///}

        Console.WriteLine("Fecha (yyyy-mm-dd):");
        var date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Descripción:");
        var description = Console.ReadLine();
        Console.WriteLine("Monto:");
        var amount = decimal.Parse(Console.ReadLine());

        manager.AddTransaction(date, description, amount ,TransactionTypes.Ingreso);
    }

    static void ShowReports(FinanceService manager)
    {
        Console.WriteLine("Total Ingresos: " + manager.GetTotalIncome());
        Console.WriteLine("Total Gastos: " + manager.GetTotalExpenses());
        Console.WriteLine("Balance Actual: " + manager.GetBalance());
    }
}
