using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Remoting.WPF
{
    public static class FrameworkElementExtensions
    {
        public static IRemoteElement ToRemotedElement(this FrameworkElement element)
        {
            return NativeHandleContractMarshalByRefObject.Create(element);
        }
    }
}
