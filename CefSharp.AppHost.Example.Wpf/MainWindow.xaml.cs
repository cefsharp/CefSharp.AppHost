using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using CefSharp.AppHost.Server;

namespace CefSharp.AppHost.Example.Server
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                var safeAppHostChildHandle = ChildProcessFactory.Create("CefSharp.AppHost.Example.Client.dll", is64Bit:true);

                var browser = (HwndHost)safeAppHostChildHandle.CreateElement(new ServiceLocator());

                BrowserContainer.Content = browser;
            }
            catch (Exception e)
            {
                Content = new TextBlock
                {
                    Text = e.ToString()
                };
            }
        }
    }
}
