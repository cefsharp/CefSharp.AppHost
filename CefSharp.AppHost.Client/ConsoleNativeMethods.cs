using System.Runtime.InteropServices;

namespace CefSharp.AppHost.Client
{
    internal static class ConsoleNativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int AllocConsole();
    }
}