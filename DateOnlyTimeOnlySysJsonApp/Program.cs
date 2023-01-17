using System.Text.Json;
using DateOnlyTimeOnlySysJsonApp.Models;
using Spectre.Console.Json;

namespace DateOnlyTimeOnlySysJsonApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        VisitorLog log = new()
        {
            VisitOn = new DateOnly(2023,1,12), 
            EnteredTime = new TimeOnly(13,15,15), 
            ExitedTime = new TimeOnly(13,45,0)
        };

        
        string jsonString = JsonSerializer.Serialize(log, 
            new JsonSerializerOptions { WriteIndented = true });

        var json = new JsonText(jsonString)
            .BracketColor(Color.Green)
            .ColonColor(Color.Blue)
            .CommaColor(Color.Red)
            .StringColor(Color.Green)
            .NumberColor(Color.Blue)
            .BooleanColor(Color.Red)
            .NullColor(Color.Green);

        AnsiConsole.Write(
            new Panel(json)
                .Header("VisitorLog serialized")
                .Collapse()
                .BorderColor(Color.White));

        Console.WriteLine();

        var deserializedLog = JsonSerializer.Deserialize<VisitorLog>(jsonString);
        AnsiConsole.MarkupLine("[white]Deserialize[/]");
        AnsiConsole.MarkupLine($"[yellow]Visited[/] {deserializedLog.VisitOn,-15}" + 
                               $"[yellow]Entered[/] {deserializedLog.EnteredTime, -15}" + 
                               $"[yellow]Exit[/] {deserializedLog.ExitedTime, -15}");

        Console.ReadLine();
    }
}