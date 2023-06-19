using Microsoft.Data.SqlClient;

namespace DateOnlyDataProviderApp.Classes;

/// <summary>
/// Extension methods to make it easy to get at DateOnly and TimeOnly
/// as done with convention data types
/// </summary>
internal static class SqlClientExtensions
{

    public static DateOnly GetDateOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);

    public static async Task<DateOnly> GetDateOnlyAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<DateOnly>(index);

    public static string GetTimeOnlyFormatted(this SqlDataReader reader, int index)
            => reader.GetFieldValue<TimeOnly>(index).ToString("hh:mm tt");

    public static string GetDateOnlyFormatted(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index).ToString("MM/dd/yyyy");

    public static TimeOnly ToTimeOnly(this TimeSpan sender)
        => TimeOnly.FromTimeSpan(sender);

    public static TimeOnly GetTimeOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index);

    public static async Task<TimeOnly> GetTimeOnlyAsync(this SqlDataReader reader, int index)
        =>  await reader.GetFieldValueAsync<TimeOnly>(index);
}