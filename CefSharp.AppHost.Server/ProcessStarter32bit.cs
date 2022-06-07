namespace CefSharp.AppHost.Server
{
    internal class ProcessStarter32Bit : ProcessStarter
    {
        internal ProcessStarter32Bit() : base ("CefSharp.AppHost.Client.x86.exe", false)
        {

        }
    }
}
