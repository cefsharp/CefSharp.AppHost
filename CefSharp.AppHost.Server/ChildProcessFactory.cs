namespace CefSharp.AppHost.Server
{
    public static class ChildProcessFactory
    {
        public static IChildProcessHandle Create(string assemblyName, bool is64Bit, bool openDebugConsole = false, bool monitorHostProcess = true)
        {
            IProcessStartOperation processStarter;

            if (is64Bit)
            {
                processStarter = new ProcessStarter64Bit();
            }
            else
            {
                processStarter = new ProcessStarter32Bit();
            }

            return new RemotedProcessBootstrapper(
                new StartProcessWithTimeout(
                    new StartProcessWithJobSupport(
                        processStarter))).Create(assemblyName, openDebugConsole, monitorHostProcess);
        }
    }
}
