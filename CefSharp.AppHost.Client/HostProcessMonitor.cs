using System;
using System.Diagnostics;

namespace CefSharp.AppHost.Client
{
    internal class HostProcessMonitor
    {
        private readonly int _hostProcessId;
        private readonly Action _onHostMissing;

        public HostProcessMonitor(int hostProcessId, Action onHostMissing)
        {
            if (onHostMissing == null)
            {
                throw new ArgumentNullException(nameof(onHostMissing));
            }

            _hostProcessId = hostProcessId;
            _onHostMissing = onHostMissing;
        }

        public void Start()
        {
            var hostProcess = Process.GetProcessById(_hostProcessId);
            hostProcess.EnableRaisingEvents = true;
            hostProcess.Exited += (sender, e) => { _onHostMissing(); };
        }
    }
}
