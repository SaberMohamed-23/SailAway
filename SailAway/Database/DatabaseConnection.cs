using MySqlConnector;

namespace SailAway.Database;

public static class DatabaseConnection
{
    // XAMPP gebruikt standaard localhost, poort 3306, gebruiker root en geen wachtwoord.
    // Heeft jouw MySQL wel een wachtwoord? Vul dat hieronder in bij Password=.
    private const string ConnectionString =
        "Server=127.0.0.1;Port=3306;Database=sailaway;User ID=root;Password=;SslMode=None;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    public static bool TestConnection(out string message)
    {
        try
        {
            using MySqlConnection connection = GetConnection();
            connection.Open();
            message = "Verbinding met de SailAway database is gelukt.";
            return true;
        }
        catch (MySqlException ex)
        {
            message = "Databaseverbinding mislukt: " + ex.Message;
            return false;
        }
    }
}
