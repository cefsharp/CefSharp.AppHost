﻿using System;
using System.Windows.Threading;
using CefSharp.AppHost.Interfaces;
using CefSharp.AppHost.Remoting.WPF;

namespace CefSharp.AppHost.Client
{
    internal class SafeChildProcessHandle : MarshalByRefObject, ISafeChildProcessHandle
    {
        private readonly Dispatcher m_UiThreadDispatcher;
        private readonly IOutOfProcessEntryPoint m_EntryPoint;

        public SafeChildProcessHandle(Dispatcher uiThreadDispatcher, IOutOfProcessEntryPoint entryPoint)
        {
            if (uiThreadDispatcher == null) 
                throw new ArgumentNullException("uiThreadDispatcher");
            
            if (entryPoint == null) 
                throw new ArgumentNullException("entryPoint");

            m_UiThreadDispatcher = uiThreadDispatcher;
            m_EntryPoint = entryPoint;
        }

        public IRemoteElement CreateElement(IAppHostServices services)
        {
            Func<IRemoteElement> createRemoteElement = () => m_EntryPoint.CreateElement(services).ToRemotedElement();

            return (IRemoteElement)m_UiThreadDispatcher.Invoke(createRemoteElement);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}