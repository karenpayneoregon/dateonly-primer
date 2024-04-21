using Microsoft.Data.SqlClient;

namespace DateOnlyApp.Extensions;

internal static class ProviderExtensions
{
    public static DateOnly BirthDate(this SqlDataReader reader)
        => reader.GetFieldValue<DateOnly>(3);

    public static DateOnly GetDateOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);

    public static async Task<DateOnly> GetDateOnlyAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<DateOnly>(index);

    public static TimeOnly ToTimeOnly(this TimeSpan sender)
        => TimeOnly.FromTimeSpan(sender);

    public static TimeOnly GetTimeOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index);

    public static async Task<TimeOnly> GetTimeOnlyAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<TimeOnly>(index);
}