using WorkingWithDateOnly.Classes;

namespace WorkingWithDateOnly;

internal partial class Program
{
    static void Main(string[] args)
    {
        JsonOperations.SerializeDeserialize();

        var rule = new Rule("[green1]DateOnly examples[/]");
        AnsiConsole.Write(rule);

        DateOnlyExamples();
        Console.WriteLine();

        rule = new Rule("[turquoise2]DateTime examples[/]");
        AnsiConsole.Write(rule);
        DateTimeExamples();

        /*
         * Parse a string to DateOnly, notice the culture
         */
        Console.WriteLine();
        var bad = "09/01/2022";
        Console.WriteLine("Assertion to determine if a string can represent a DateOnly");
        if (DateOnly.TryParse(bad, new CultureInfo("en"), DateTimeStyles.None, out var date))
        {
            AnsiConsole.MarkupLine($"Valid [cyan]{date}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed[/]");
        }


        bad = "28/09/2022";
        if (DateOnly.TryParse("28/09/2022", new CultureInfo("en"), DateTimeStyles.None, out var result))
        {
            Console.WriteLine(result);
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Failed[/] {bad}");
        }

        Console.ReadLine();
    }
}