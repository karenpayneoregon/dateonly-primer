using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace DateOnlyDataProviderApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample: DateOnly/TimeOnly using Microsoft.Data.SqlClient preview";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
