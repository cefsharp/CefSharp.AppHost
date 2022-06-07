using System.Diagnostics;

namespace CefSharp.AppHost.Server
{
    internal interface IProcessStartOperation
    {
        Process StartProcess(string assemblyName, string remotingId, bool openDebugConsole, bool monitorHostProcess);
    }
}