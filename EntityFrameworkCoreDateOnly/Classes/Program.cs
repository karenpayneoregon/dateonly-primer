using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace DateOnlyApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "EF Core 6 DateOnly code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
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
