using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Example.Client
{
    public class OutOfProcessEntryPoint : IOutOfProcessEntryPoint
    {
        public FrameworkElement CreateElement(IAppHostServices service)
        {
            return new BrowserUserControl();
        }
    }
}
