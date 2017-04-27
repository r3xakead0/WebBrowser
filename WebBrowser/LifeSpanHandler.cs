using CefSharp.WinForms;
using CefSharp;

namespace WebBrowser
{
    public class LifeSpanHandler : ILifeSpanHandler
    {


        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
         
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
            
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            //var windowX = (windowInfo.X == int.MinValue) ? double.NaN : windowInfo.X;
            //var windowY = (windowInfo.Y == int.MinValue) ? double.NaN : windowInfo.Y;
            //var windowWidth = (windowInfo.Width == int.MinValue) ? double.NaN : windowInfo.Width;
            //var windowHeight = (windowInfo.Height == int.MinValue) ? double.NaN : windowInfo.Height;

            ChromiumWebBrowser chromiumBrowser = null;
            /*
               it is a website which have a scripts that start a new popup 
               on its first page and when I want to grab the handler of the 
               popup window in a new page the scripts of the page understand
               this and reopen a new popup window which I want to grab its 
               handler too.
            */
            chromiumBrowser = new ChromiumWebBrowser(targetUrl);
            chromiumBrowser.SetAsPopup();
            chromiumBrowser.LifeSpanHandler = this;
            newBrowser = chromiumBrowser;
            return true; //Infinite loop
        }
    }
}
