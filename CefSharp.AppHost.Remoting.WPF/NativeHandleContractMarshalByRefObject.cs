using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Remoting.WPF
{
    internal class NativeHandleContractMarshalByRefObject : MarshalByRefObject, IRemoteElement
    {
        private readonly INativeHandleContract _upstream;

        internal static NativeHandleContractMarshalByRefObject Create(FrameworkElement element)
        {
            return new NativeHandleContractMarshalByRefObject(FrameworkElementAdapters.ViewToContractAdapter(element));
        }        

        private NativeHandleContractMarshalByRefObject(INativeHandleContract upstream)
        {
            _upstream = upstream;
        }

        public override object InitializeLifetimeService()
        {
            return null;
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

        public long GetHandle()
        {
            return (long)_upstream.GetHandle();
        }
    }
}