using System;
using System.Windows.Forms;
using System.Configuration;
using System.Text;
using CefSharp;
using CefSharp.WinForms;
using log4net;

namespace WebBrowser
{
    public partial class FrmBrowser : Form
    {

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ChromiumWebBrowser browser;

        public FrmBrowser()
        {

            try
            {

                InitializeComponent();

                string url = ConfigurationSettings.AppSettings["url"];

                browser = new ChromiumWebBrowser(url)
                {
                    Dock = DockStyle.Fill
                };

                this.Controls.Add(browser);

                this.browser.LifeSpanHandler = new LifeSpanHandler();

                this.browser.LoadingStateChanged += OnLoadingStateChanged;
                this.browser.ConsoleMessage += OnBrowserConsoleMessage;
                this.browser.StatusMessage += OnBrowserStatusMessage;
                this.browser.TitleChanged += OnBrowserTitleChanged;
                this.browser.AddressChanged += OnBrowserAddressChanged;

                log.Info("Ready");

            }
            catch (Exception ex)
            {
                StringBuilder error = new StringBuilder();

                error.AppendLine("Message   : " + ex.Message.ToString());
                error.AppendLine("Trace     : " + ex.StackTrace.ToString());

                log.Error(error);
            }

        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            
        }

    }
}
