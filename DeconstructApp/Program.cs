using DeconstructApp.Classes;

namespace DeconstructApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var (day, month, year) = Sample1();
        AnsiConsole.MarkupLine($"{month}  {day}  {year}");
        var (hour, minutes, _) = Sample2();
        AnsiConsole.MarkupLine($"{hour}  {minutes}");

        Console.ReadLine();
    }

    static DateOnly Sample1() => new(2023, 7, 11);
    static TimeOnly Sample2() => new(13,15, 15);
}