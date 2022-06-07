using System;
using CefSharp.AppHost.Interfaces;

namespace CefSharp.AppHost.Example.Server
{
    public class ServiceLocator : MarshalByRefObject, IAppHostServices
    {
        public T GetService<T>() where T : class
        {
            return new ServerImplementedThingThatClientNeeds() as T;
        }
    }
}