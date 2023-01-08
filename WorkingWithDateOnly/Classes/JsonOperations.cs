using WorkingWithDateOnly.Models;

namespace WorkingWithDateOnly.Classes;

internal class JsonOperations
{
    public static string FileName { get; set; } 
        = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.json");

    /// <summary>
    /// Example to show how to serialize and deserialize <see cref="DateOnly"/> using <see cref="DateOnlyConverter"/>
    /// </summary>
    public static void SerializeDeserialize()
    {
        JsonSerializerOptions JsonSerializerOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General);

            jsonSerializerOptions.Converters.Add(new DateOnlyConverter());
            jsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
            jsonSerializerOptions.WriteIndented = true;

            return jsonSerializerOptions;

        }

        var list = PeopleMocked();

        // setup for to use DateOnlyConverter
        var options = JsonSerializerOptions();


        File.WriteAllText(FileName, JsonSerializer.Serialize(list, options));
 
        var peopleList = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(FileName), options);
        // set breakpoint to see the results or do a foreach

    }

    private static List<Person> PeopleMocked() =>
        new()
        {
            new Person()
            {
                PersonId = 1, 
                FirstName = "Karen",
                LastName = "Payne", 
                BirthDate = new DateOnly(1956, 9, 24), 
                TimeOnly = new TimeOnly(13,0)
            },
            new Person()
            {
                PersonId = 2, 
                FirstName = "Mary", 
                LastName = "Adams", 
                BirthDate = new DateOnly(1959, 3, 24),
                TimeOnly = new TimeOnly(14,30)
            },
            new Person()
            {
                PersonId = 3, 
                FirstName = "Jim", 
                LastName = "Smith", 
                BirthDate = new DateOnly(1987, 3, 15),
                TimeOnly = new TimeOnly(3,10)
            }
        };
}