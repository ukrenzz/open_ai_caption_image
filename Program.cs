using System.Configuration;
using System.Collections.Specialized;
using AC_Image.Services;

namespace AC_Image
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
            createImageCacheFolder();


            Application.Run(new MainForm());
            //Application.Run(new Testing());
        }

        static void createImageCacheFolder()
        {
            string imageCacheDirectory = AppService.GetImageCacheDirectory();

            Directory.CreateDirectory(imageCacheDirectory);
        }
    }
}