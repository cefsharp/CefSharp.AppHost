namespace RedGate.AppHost.Server
{
    internal class ProcessStarter32Bit : ProcessStarter
    {
        internal ProcessStarter32Bit() : base ("RedGate.AppHost.Client.x86.exe", false)
        {

        }
    }
}
