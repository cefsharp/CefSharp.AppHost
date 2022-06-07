using System.Diagnostics;
using System.Runtime.Remoting;
using System.Windows;
using CefSharp.AppHost.Interfaces;
using CefSharp.AppHost.Remoting.WPF;

namespace CefSharp.AppHost.Server
{
    internal class ChildProcessHandle : IChildProcessHandle
    {
        private readonly ISafeChildProcessHandle _safeChildProcessHandle;
        private readonly Process _process;

        public ChildProcessHandle(ISafeChildProcessHandle safeChildProcessHandle, Process process)
        {
            _safeChildProcessHandle = safeChildProcessHandle;
            _process = process;
        }

        public FrameworkElement CreateElement(IAppHostServices services)
        {
            try
            {
                return _safeChildProcessHandle.CreateElement(services).ToFrameworkElement();
            }
            catch (RemotingException)
            {
                _process?.KillAndDispose();

                throw;
            }
        }
    }
}