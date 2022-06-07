﻿using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Remoting.WPF
{
    internal class NativeHandleContractMarshalByRefObject : MarshalByRefObject, IRemoteElement
    {
        internal static NativeHandleContractMarshalByRefObject Create(FrameworkElement element)
        {
            return new NativeHandleContractMarshalByRefObject(FrameworkElementAdapters.ViewToContractAdapter(element));
        }

        private readonly INativeHandleContract m_Upstream;

        private NativeHandleContractMarshalByRefObject(INativeHandleContract upstream)
        {
            m_Upstream = upstream;
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public IContract QueryContract(string contractIdentifier)
        {
            return m_Upstream.QueryContract(contractIdentifier);
        }

        public int GetRemoteHashCode()
        {
            return m_Upstream.GetRemoteHashCode();
        }

        public bool RemoteEquals(IContract contract)
        {
            return m_Upstream.RemoteEquals(contract);
        }

        public string RemoteToString()
        {
            return m_Upstream.RemoteToString();
        }

        public int AcquireLifetimeToken()
        {
            return m_Upstream.AcquireLifetimeToken();
        }

        public void RevokeLifetimeToken(int token)
        {
            m_Upstream.RevokeLifetimeToken(token);
        }

        public long GetHandle()
        {
            return (long)m_Upstream.GetHandle();
        }
    }
}