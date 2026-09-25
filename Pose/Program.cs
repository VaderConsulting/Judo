namespace Pose
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //AppDomain.CurrentDomain.UnhandledException += (sender, e) => Debug.WriteLine($"[CRITICAL] Unhandled exception: {e.ExceptionObject}");

            //Application.ThreadException += (sender, e) =>
            //{
            //    Debug.WriteLine($"[CRITICAL] Thread exception: {e.Exception.Message}");
            //    _ = MessageBox.Show($"A critical error occurred: {e.Exception.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //};
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"A critical error occurred: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}