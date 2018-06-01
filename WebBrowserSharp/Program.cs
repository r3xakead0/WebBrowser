using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using CefSharp;
using log4net;

namespace WebBrowserSharp
{
    
    static class Program
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //For Windows 7 and above, best to include relevant app.manifest entries as well
                Cef.EnableHighDPISupport();

                var settings = new CefSettings()
                {
                    //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                    CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
                };

                //Perform dependency check to make sure all relevant resources are in our output directory.
                Cef.Initialize(settings);

                var browser = new FrmBrowser();

                Application.Run(browser);
            }
            catch (Exception ex)
            {
                StringBuilder error = new StringBuilder();

                error.AppendLine("Message   : " + ex.Message.ToString());
                error.AppendLine("Trace     : " + ex.StackTrace.ToString());

                log.Error(error);
            }
        }
    }
}
