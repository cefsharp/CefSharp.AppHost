namespace CefSharp.AppHost.Server
{
    public static class ChildProcessFactory
    {
        public static IChildProcessHandle Create(string assemblyName, bool is64Bit, bool openDebugConsole = false, bool monitorHostProcess = true)
        {
            var processStarter = new ProcessStarter(is64Bit ? "CefSharp.AppHost.Client.x64.exe" : "CefSharp.AppHost.Client.x86.exe");

            return new RemotedProcessBootstrapper(
                new StartProcessWithTimeout(
                    new StartProcessWithJobSupport(
                        processStarter))).Create(assemblyName, openDebugConsole, monitorHostProcess);
        }
    }
}
