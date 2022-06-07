﻿using System.Windows;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Server
{
    /// <summary>
    /// A handle to a process, which when initialized, returns a FrameworkElement for rendering
    /// </summary>
    public interface IChildProcessHandle
    {
        FrameworkElement CreateElement(IAppHostServices services);
    }
}