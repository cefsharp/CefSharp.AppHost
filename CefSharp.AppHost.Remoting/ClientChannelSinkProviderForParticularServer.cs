using System;
using System.Runtime.Remoting.Channels;

namespace CefSharp.AppHost.Remoting
{
    internal class ClientChannelSinkProviderForParticularServer : IClientChannelSinkProvider
    {
        private readonly IClientChannelSinkProvider _upstream;
        private readonly string _url;

        internal ClientChannelSinkProviderForParticularServer(IClientChannelSinkProvider upstream, string id)
        {
            if (upstream == null) 
                throw new ArgumentNullException(nameof(upstream));

            if (string.IsNullOrEmpty(id)) 
                throw new ArgumentNullException(nameof(id));

            _upstream = upstream;
            _url = string.Format("ipc://{0}", id);
        }

        public IClientChannelSinkProvider Next
        {
            get { return _upstream.Next; }
            set { _upstream.Next = value; }
        }

        public IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData)
        {
            //Returning null indicates that the sink cannot be created as per Microsoft documentation
            return url == _url ? _upstream.CreateSink(channel, url, remoteChannelData) : null;
        }
    }
}