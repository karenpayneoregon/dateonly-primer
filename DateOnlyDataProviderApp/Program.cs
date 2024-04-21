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
        Console.WriteLine(); // set breakpoint here and view in local window

        AnsiConsole.MarkupLine("[yellow]Dapper example[/]");
        var dapperResult = await DataOperations.DataReaderDapperExample();
        foreach (var log in dapperResult)
        {
            Console.WriteLine($"{log.VisitOn,-12:MM/dd/yyyy}{log.EnteredTime,-15:HH:mm tt}{log.ExitedTime:HH:mm tt}");
        }

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
                $"{row.ToDateOnly("VisitOn").ToString("MM/dd/yyyy"),-12}" + 
                $"{row.ToTimeOnly("EnteredTime").ToString("hh:mm:ss tt"),-15}" + 
                $"{row.ToTimeOnly("ExitedTime").ToString("hh:mm:ss tt")}");

            
        }

        AnsiConsole.MarkupLine("[yellow]Press ENTER to exit[/]");
        Console.ReadLine();
    }
}