using System.Diagnostics;

namespace QuizApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InicializeDirectories();
            Application.Run(new Menu());
        }

        private static void InicializeDirectories()
        {
            string BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            BaseDir = BaseDir + "Resources\\";
            Debug.WriteLine(BaseDir);

            if (!Directory.Exists(BaseDir))
            {
                Directory.CreateDirectory(BaseDir);
            }
            BaseDir = BaseDir + "Images\\";
            Debug.WriteLine(BaseDir);

            if (!Directory.Exists(BaseDir))
            {
                Directory.CreateDirectory(BaseDir);
            }
        }
    }
}