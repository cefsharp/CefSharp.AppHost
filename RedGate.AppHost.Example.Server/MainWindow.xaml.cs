using System;
using System.Windows;
using System.Windows.Controls;
using RedGate.AppHost.Server;

namespace RedGate.AppHost.Example.Server
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                var safeAppHostChildHandle = ChildProcessFactory.Create("RedGate.AppHost.Example.Client.dll", is64Bit:true);

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
