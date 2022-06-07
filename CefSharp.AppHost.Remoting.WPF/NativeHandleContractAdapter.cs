using System;
using System.AddIn.Contract;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Remoting.WPF
{
    internal class NativeHandleContractAdapter : INativeHandleContract
    {
        private readonly IRemoteElement _upstream;

        internal NativeHandleContractAdapter(IRemoteElement upstream)
        {
            if (upstream == null)
            {
                throw new ArgumentNullException(nameof(upstream));
            }
            _upstream = upstream;
        }


        public IContract QueryContract(string contractIdentifier)
        {
            return _upstream.QueryContract(contractIdentifier);
        }

        public int GetRemoteHashCode()
        {
            return _upstream.GetRemoteHashCode();
        }

        public bool RemoteEquals(IContract contract)
        {
            return _upstream.RemoteEquals(contract);
        }

        public string RemoteToString()
        {
            return _upstream.RemoteToString();
        }

        public int AcquireLifetimeToken()
        {
            return _upstream.AcquireLifetimeToken();
        }

        public void RevokeLifetimeToken(int token)
        {
            _upstream.RevokeLifetimeToken(token);
        }

        public IntPtr GetHandle()
        {
            return (IntPtr)_upstream.GetHandle();
        }
    }
}