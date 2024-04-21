#nullable disable
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateOnlyApp1.Classes;

/// <summary>
/// Not needed when using EF Core 8 and higher
/// </summary>
internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)) { }
}