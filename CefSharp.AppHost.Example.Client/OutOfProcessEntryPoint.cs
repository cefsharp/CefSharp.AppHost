using System.Windows;
using CefSharp.AppHost.Example.Remote.Services;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Example.Client
{
    public class OutOfProcessEntryPoint : IOutOfProcessEntryPoint
    {
        public FrameworkElement CreateElement(IAppHostServices service)
        {
            var serverThing = service.GetService<IServerImplementedThingThatClientNeeds>();

            string textToDisplay = serverThing.GetTextToDisplay();

            return new UserControl1(textToDisplay);
        }
    }
}
