using Microsoft.Data.SqlClient;

namespace DateOnlyApp.Extensions;

internal static class ProviderExtensions
{
    public static DateOnly BirthDate(this SqlDataReader reader)
        => reader.GetFieldValue<DateOnly>(3);

    public static DateOnly BirthDate(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);
}