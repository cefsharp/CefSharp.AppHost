using System;
using System.Diagnostics;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Server
{
    internal class RemotedProcessBootstrapper
    {
        private readonly IProcessStartOperation _processBootstrapper;
        private readonly string _remotingId = string.Format("CefSharp.AppHost.IPC.{{{0}}}", Guid.NewGuid());

        public RemotedProcessBootstrapper(IProcessStartOperation processBootstrapper)
        {
            if (processBootstrapper == null)
                throw new ArgumentNullException("processBootstrapper");

            _processBootstrapper = processBootstrapper;
        }

        public IChildProcessHandle Create(string assemblyName, bool openDebugConsole, bool monitorHostProcess)
        {
            Process process = null;

            try
            {
                process = _processBootstrapper.StartProcess(assemblyName, _remotingId, openDebugConsole, monitorHostProcess);
                return new ChildProcessHandle(InitializeRemoting(), process);
            }
            catch
            {
                process?.KillAndDispose();

                throw;
            }
        }

        private ISafeChildProcessHandle InitializeRemoting()
        {
            Remoting.Remoting.RegisterChannels(false, _remotingId);

            return Remoting.Remoting.ConnectToService<ISafeChildProcessHandle>(_remotingId);
        }
    }
}