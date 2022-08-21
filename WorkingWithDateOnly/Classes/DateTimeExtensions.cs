namespace WorkingWithDateOnly.Classes;

static class  DateTimeExtensions
{
    public static string[] Formatted(this DateTime[] sender) 
        => sender.Select(x => x.ToShortDateString()).ToArray();
    public static string[] Formatted(this List<DateTime> sender) 
        => sender.Select(x => x.ToShortDateString()).ToArray();
}