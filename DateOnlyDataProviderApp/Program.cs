using System.Data;
using DateOnlyDataProviderApp.Classes;

namespace DateOnlyDataProviderApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]One record via DataReader[/]");
        var readerResults = await DataOperations.DataReaderExample();

        Console.WriteLine(readerResults);

        var readerLoopResult = await DataOperations.DataReaderLoopExample();
        Console.WriteLine();

        AnsiConsole.MarkupLine("[yellow]All records via DataTable[/]");

        /*
         * The DataTable does not understand DateOnly so the column VisitOn will be
         * DateTime, not DateOnly
         */
        var tableResult = await DataOperations.DataTableExample();
        
        foreach (DataRow row in tableResult.Rows)
        {
            Console.WriteLine(
                $"{DateOnly.FromDateTime(row.Field<DateTime>("VisitOn")).ToString("MM/dd/yyyy"),-12}" + 
                $"{row.Field<TimeSpan>("EnteredTime").ToTimeOnly().ToString("hh:mm:ss tt"),-15}" + 
                $"{row.Field<TimeSpan>("ExitedTime").ToTimeOnly().ToString("hh:mm:ss tt")}");
        }

        AnsiConsole.MarkupLine("[yellow]Press ENTER to exit[/]");
        Console.ReadLine();
    }
}