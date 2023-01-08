using System.Runtime.CompilerServices;
using WorkingWithDateOnly.Classes;

// ReSharper disable once CheckNamespace
namespace WorkingWithDateOnly;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");

        // notice how to get today's date from DateOnly
        Console.Title = $"DateOnly code samples: run on {DateOnly.FromDateTime(DateTime.Now)}";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    internal static void DateOnlyExamples()
    {
        Helpers.PrintSampleName();

        List<DateOnly> dates = DateOnlyMethods.GetMonthDays(DateTime.Now.Month);
        List<DateOnly[]> chunked = dates.Chunk(7).ToList();
            

        AnsiConsole.MarkupLine($"[cyan]Dates in[/]  [b]{DateOnlyMethods.MonthName}[/]\n");

        foreach (var item in chunked)
        {
            Console.WriteLine(string.Join(",", item));
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]Next week's dates[/]");
        List<DateOnly> nextWeeksDates = DateOnlyMethods.NextWeeksDates();

        Console.WriteLine(string.Join(",", nextWeeksDates));
    }
    internal static void DateTimeExamples()
    {
        Helpers.PrintSampleName();

        List<DateTime> dates = DateTimeMethods.GetMonthDays(DateTime.Now.Month);
        List<DateTime[]> chunked = dates.Chunk(7).ToList();


        AnsiConsole.MarkupLine($"[cyan]Dates in[/]  [b]{DateTimeMethods.MonthName}[/]\n");

        foreach (DateTime[] item in chunked)
        {
            Console.WriteLine(string.Join(",", item.Formatted()));
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]Next week's dates[/]");
        List<DateTime> nextWeeksDates = DateTimeMethods.NextWeeksDates();

        Console.WriteLine(string.Join(",", nextWeeksDates.Formatted()));
    }


}
internal class Helpers
{
    public static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]>>>> Sample:[/] [white]{methodName}[/]");
        Console.WriteLine();
    }
}