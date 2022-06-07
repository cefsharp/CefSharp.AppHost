﻿using CommandLine;

namespace CefSharp.AppHost.Client
{
    internal class Options
    {
        [Option('a', "assembly", Required = true, HelpText = "Assembly that contains an IOutOfProcessEntryPoint to load")]
        public string Assembly { get; set; }

        [Option('i', "id", Required = true, HelpText = "The communication channel to call back to the host")]
        public string ChannelId { get; set; }

        [Option('d', "debug", Required = false, HelpText = "Opens the client in debug mode")]
        public bool Debug { get; set; }

        [Option('p', "processid", Required = false, HelpText = "Exits the process if the host process with the given id exits")]
        public int? HostProcessId { get; set; }
    }
}