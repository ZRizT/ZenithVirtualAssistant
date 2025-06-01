using Microsoft.Data.Sqlite;
using ZenithVirtualAssistant.Core.Models;

namespace ZenithVirtualAssistant.Core.Services;

public class DatabaseService
{
    private readonly string _connectionString = "Data Source=zenith.db";

    public DatabaseService()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Commands (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Trigger TEXT NOT NULL,
                Action TEXT NOT NULL,
                Response TEXT
            )";
        command.ExecuteNonQuery();
    }

    public void SaveCommand(Command command)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var cmd = connection.CreateCommand();
        cmd.CommandText = "INSERT INTO Commands (Trigger, Action, Response) VALUES ($trigger, $action, $response)";
        cmd.Parameters.AddWithValue("$trigger", command.Trigger);
        cmd.Parameters.AddWithValue("$action", command.Action);
        cmd.Parameters.AddWithValue("$response", command.Response);
        cmd.ExecuteNonQuery();
    }
}