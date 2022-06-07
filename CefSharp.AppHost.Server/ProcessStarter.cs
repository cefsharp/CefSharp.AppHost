using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CefSharp.AppHost.Server
{
    internal class ProcessStarter : IProcessStartOperation
    {
        private string _processFileName;

        internal ProcessStarter(string processsFileName)
        {
            _processFileName = processsFileName;
        }

        public Process StartProcess(string assemblyName, string remotingId, bool openDebugConsole, bool monitorHostProcess)
        {
            string executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string quotedAssemblyArg = "\"" + Path.Combine(executingDirectory, assemblyName) + "\"";

            var processToStart = Path.Combine(executingDirectory, _processFileName);
            var processArguments = string.Join(" ", new[]
            {
                "-i " + remotingId,
                "-a " + quotedAssemblyArg,
                openDebugConsole ? "-d" : string.Empty,
                monitorHostProcess ? "-p " + Process.GetCurrentProcess().Id : string.Empty
            });
            return Process.Start(processToStart, processArguments);
        }
    }
}
