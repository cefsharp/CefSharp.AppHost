using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Remoting.WPF
{
    public static class RemoteElementExtensions
    {
        public static FrameworkElement ToFrameworkElement(this IRemoteElement remotedElement)
        {
            INativeHandleContract nativeHandleContractAdapter = new NativeHandleContractAdapter(remotedElement);

            return FrameworkElementAdapters.ContractToViewAdapter(nativeHandleContractAdapter);
        }
    }
}