using System.Runtime.CompilerServices;
using DateOnlyApp.Data;
using DateOnlyApp.Extensions;

// ReSharper disable once CheckNamespace
namespace DateOnlyApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "EF Core 7 DateOnly code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);


            // uncomment for the first run to create the database and add two records
            //using var context = new Context();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
        }

        internal class Helpers
        {
            public static void PrintSampleName([CallerMemberName] string? methodName = null)
            {
                AnsiConsole.MarkupLine($"[cyan]>>>> Sample:[/] [white]{methodName}[/]");
                Console.WriteLine();
            }
        }
        public static Table CreateTable()
        {
            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Id[/]")
                .AddColumn("[b]First[/]")
                .AddColumn("[b]Last[/]")
                .AddColumn("[b]Birth date[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[LightGreen]People[/]");
            return table;
        }
    }
}
