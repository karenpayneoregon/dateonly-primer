using System.Data;

namespace DateOnlyDataProviderApp.Classes;
public static class DataRowExtensions
{
    public static DateOnly ToDateOnly(this DataRow row, string columnName) 
        => DateOnly.FromDateTime(row.Field<DateTime>(columnName));

    public static TimeOnly ToTimeOnly(this DataRow row, string columnName) 
        => row.Field<TimeSpan>(columnName).ToTimeOnly();
}
