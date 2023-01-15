using System.Data;
using ConfigurationLibrary.Classes;
using DateOnlyDataProviderApp.Models;
using Microsoft.Data.SqlClient;

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

        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();

        reader.Read();

        return new VisitorLog()
        {
            VisitOn = reader.GetDateOnly(0), 
            EnteredTime = reader.GetTimeOnly(1), 
            ExitedTime = reader.GetTimeOnly(2)
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

        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        await using var reader = await cmd.ExecuteReaderAsync();



        while (reader.Read())
        {
            list.Add(new VisitorLog()
            {
                VisitOn = reader.GetDateOnly(0),
                EnteredTime = reader.GetTimeOnly(1),
                ExitedTime = reader.GetTimeOnly(2)
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

        await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

        await cn.OpenAsync();
        
        DataTable dataTable = new DataTable();

        dataTable.Load(await cmd.ExecuteReaderAsync());
        return dataTable;

    }
}