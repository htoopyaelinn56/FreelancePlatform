using MySql.Data.MySqlClient;

namespace FreelancePlatform.src
{
    internal class DatabaseService
    {
        private static MySqlConnection? _connection;

        // Change to your own credentials
        private static readonly string _connectionString =
            "server=localhost;user=root;password=root;database=world;";

        public static void Initialize()
        {
            try
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static MySqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("Database connection is not initialized or already closed.");

            return _connection;
        }

        public static void Close()
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing database: " + ex.Message);
            }
        }
    }
}
