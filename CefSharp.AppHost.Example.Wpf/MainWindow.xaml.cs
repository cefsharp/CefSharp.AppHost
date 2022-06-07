using System;
using System.Windows;
using System.Windows.Controls;
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

                Content = safeAppHostChildHandle.CreateElement(new ServiceLocator());
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
