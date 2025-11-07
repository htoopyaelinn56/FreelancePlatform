namespace FreelancePlatform.src
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnApplicationExit;

            try
            {
                // Initialize database when app starts
                DatabaseService.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database initialization failed:\n" + ex.Message);
                return; // Stop app if connection fails
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new AuthenticationForm());
        }

        private static void OnApplicationExit(object? sender, EventArgs e)
        {
            // Close DB connection on app exit
            DatabaseService.Close();
        }
    }
}