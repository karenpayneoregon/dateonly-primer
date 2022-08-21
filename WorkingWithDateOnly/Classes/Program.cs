using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkingWithDateOnly.Classes;

// ReSharper disable once CheckNamespace
namespace WorkingWithDateOnly
{
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
            var dates = DateOnlyMethods.GetMonthDays(DateTime.Now.Month);
            var chunked = dates.Chunk(7).ToList();
            

            AnsiConsole.MarkupLine($"[cyan]Dates in[/]  [b]{DateOnlyMethods.MonthName}[/]\n");

            foreach (var item in chunked)
            {
                Console.WriteLine(string.Join(",", item));
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine("[cyan]Next week's dates[/]");
            var nextWeeksDates = DateOnlyMethods.NextWeeksDates();

            Console.WriteLine(string.Join(",", nextWeeksDates));
        }
        internal static void DateTimeExamples()
        {
            var dates = DateTimeMethods.GetMonthDays(DateTime.Now.Month);
            var chunked = dates.Chunk(7).ToList();


            AnsiConsole.MarkupLine($"[cyan]Dates in[/]  [b]{DateTimeMethods.MonthName}[/]\n");

            foreach (DateTime[] item in chunked)
            {
                Console.WriteLine(string.Join(",", item.Formatted()));
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine("[cyan]Next week's dates[/]");
            var nextWeeksDates = DateTimeMethods.NextWeeksDates();

            Console.WriteLine(string.Join(",", nextWeeksDates.Formatted()));
        }


    }
}
