namespace DeconstructApp.Classes;
internal static class Helpers
{
    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
        (day, month, year) = (date.Day, date.Month, date.Year);

    public static void Deconstruct(this TimeOnly time, out int hour, out int minutes, out int seconds, out int milliseconds)
        => (hour, minutes, seconds, milliseconds) = (time.Hour, time.Minute, time.Second, time.Microsecond);

    public static void Deconstruct(this TimeOnly time, out int hour, out int minutes, out int seconds)
        => (hour, minutes, seconds) = (time.Hour, time.Minute, time.Second);
}
