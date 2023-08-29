using System.Data;
using DateOnlyDataProviderApp.Models;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace DateOnlyDataProviderApp.Classes;

internal class DataOperations
{
    /// <summary>
    /// Example for reading <see cref="DateOnly"/> and <see cref="TimeOnly"/> with <see cref="SqlDataReader"/>
    /// </summary>
    /// <returns></returns>
    public static async Task<VisitorLog> DataReaderExample()
    {
  
        var statement = """
            SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime 
            FROM Visitor AS V  
            INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier 
            WHERE (V.VisitorIdentifier = 1);
            """;

        await using SqlConnection cn = new(ConnectionString());
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();

        reader.Read();

        return new VisitorLog()
        {
            VisitOn = await reader.GetDateOnlyAsync(0), 
            EnteredTime = await reader.GetTimeOnlyAsync(1), 
            ExitedTime = await reader.GetTimeOnlyAsync(2)
        };

    }

    public static async Task<List<VisitorLog>> DataReaderLoopExample()
    {

        List<VisitorLog> list = new();
        var statement = """
            SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime 
            FROM Visitor AS V  
            INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier 
            """;

        await using SqlConnection cn = new(ConnectionString());
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();
        
        while (reader.Read())
        {
            list.Add(new VisitorLog()
            {
                VisitOn = await reader.GetDateOnlyAsync(0),
                EnteredTime = await reader.GetTimeOnlyAsync(1),
                ExitedTime = await reader.GetTimeOnlyAsync(2)
            });
        }

        return list;

    }

    public static async Task<DataTable> DataTableExample()
    {

        var statement = """
            SELECT VL.VisitOn, VL.EnteredTime, VL.ExitedTime 
            FROM Visitor AS V  
            INNER JOIN VisitorLog AS VL ON V.VisitorIdentifier = VL.VisitorIdentifier 
            """;

        await using SqlConnection cn = new(ConnectionString());
        await using SqlCommand cmd = new() { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        
        DataTable dataTable = new();

        dataTable.Load(await cmd.ExecuteReaderAsync());
        return dataTable;

    }
}