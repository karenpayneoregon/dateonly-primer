# EF Core 6 DateOnly

Many post on the web will say `DateOnly` is a long time coming, let’s skip that.

Let's see a simple example

```csharp
DateOnly exampleDateOnly = new DateOnly(2022, 8, 21);
Console.WriteLine(exampleDateOnly);
```

Which outputs 8/21/2022


What is great about `DateOnly` is we can now query a date type in a SQL-Server database table.

For this example we have a DateOnly column, BirthDate.

![Person Schema](assets/personSchema.png)


**Model**

```csharp
public partial class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly? BirthDate { get; set; } 
}
```

As with other code samples in this repository we can use [HaveConversion](https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations)

The model above after reverse engineering had DateTime, I changed it to DateOnly following by implementing a class to perform a conversion from DateTime to DateOnly.

```csharp
internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d)) { }
}
```

Then in the DbContext to perform conversions on any column that is DateOnly.

```csharp
protected override void ConfigureConventions(ModelConfigurationBuilder builder)
{
    builder.Properties<DateOnly>()
        .HaveConversion<DateOnlyConverter>()
        .HaveColumnType("date");
    base.ConfigureConventions(builder);
}
```

Results from reading data

![Main](assets/main.png)


# Script

The script under the Scripts folder is the same as HasConversion project with the addition of the Person table


# References

- Microsoft docs [DateOnly Struct](https://docs.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-6.0)