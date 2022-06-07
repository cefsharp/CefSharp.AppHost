﻿using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Windows;
using CefSharp.AppHost.Interfaces;
using CefSharp.AppHost.Remoting.WPF;

namespace CefSharp.AppHost.Server
{
    internal class ChildProcessHandle : IChildProcessHandle
    {
        private readonly ISafeChildProcessHandle m_SafeChildProcessHandle;
        private readonly Process m_Process;

        public ChildProcessHandle(ISafeChildProcessHandle safeChildProcessHandle, Process process)
        {
            m_SafeChildProcessHandle = safeChildProcessHandle;
            m_Process = process;
        }

        public FrameworkElement CreateElement(IAppHostServices services)
        {
            try
            {
                return m_SafeChildProcessHandle.CreateElement(services).ToFrameworkElement();
            }
            catch (RemotingException)
            {
                if (m_Process != null)
                {
                    m_Process.KillAndDispose();
                }
                throw;
            }
        }
    }
}