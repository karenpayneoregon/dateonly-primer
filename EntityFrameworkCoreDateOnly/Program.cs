﻿using DateOnlyApp.Data;
using DateOnlyApp.Extensions;
using DateOnlyApp.Models;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace DateOnlyApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        await using var context = new Context();
        var success = await context.CanConnectAsync(cancellationTokenSource.Token);

        if (success)
        {
            await UsingSqlClientDataProvider();
            await UsingEntityFrameworkCore();
        }
        else
        {
            AnsiConsole.MarkupLine("[white on red]Failed to connect to database, did you create it?[/]");
            AnsiConsole.MarkupLine("[white on red]if not created see code in Classes\\Program[/]");
        }


        var people = await ReadPeople();

        AnsiConsole.MarkupLine("Press [b]ENTER[/] to exit");
        Console.ReadLine();
    }

    /// <summary>
    /// Present data via EF Core 7
    /// </summary>
    private static async Task UsingEntityFrameworkCore()
    {
        Helpers.PrintSampleName();

        await using var context = new Context();

        var table = CreateTable();

        var people = context.Person.ToList();

        foreach (var person in people)
        {
            table.AddRow(person.PersonId.ToString(), person.FirstName, person.LastName,
                person.BirthDate!.Value.ToString("MM/dd/yyyy"));
        }


        AnsiConsole.Write(table);
    }

    /// <summary>
    /// Present data using a preview version of SqlClient data provider
    /// </summary>
    /// <returns></returns>
    public static async Task UsingSqlClientDataProvider()
    {

        Helpers.PrintSampleName();

        var statement = "SELECT PersonId,FirstName,LastName,BirthDate FROM dbo.Person";

        await using var cn = new SqlConnection(ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };
        
        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();

        while (reader.Read())
        {
            AnsiConsole.MarkupLine($"[yellow]{reader.BirthDate().ToString("MM/dd/yyyy")}[/] " + 
                                   $"[cyan]{reader.BirthDate()}[/]");

        }

        Console.WriteLine();
    }

    public static async Task<List<Person>> ReadPeople()
    {
        const string statement = 
            """
            SELECT PersonId,FirstName,LastName,BirthDate 
            FROM dbo.Person
            """;

        await using SqlConnection cn = new(ConnectionString());
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using SqlDataReader? reader = await cmd.ExecuteReaderAsync();

        List<Person> list = [];

        while (await reader.ReadAsync())
        {
            
            list.Add(new Person()
            {
                PersonId = await reader.GetIntAsync(0), 
                FirstName = await reader.GetStringAsync(1),
                LastName = await reader.GetStringAsync(2),
                BirthDate = await reader.GetDateOnlyAsync(3)
            });
        }

        return list;

    }
}