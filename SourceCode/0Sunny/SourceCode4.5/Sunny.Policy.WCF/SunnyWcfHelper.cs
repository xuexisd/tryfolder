using Microsoft.Practices.Unity.Utility;
using System;
using System.Collections;
using System.ServiceModel;

namespace Sunny.Policy.WCF
{
    public static class SunnyWcfHelper
    {
        private static readonly Hashtable endpointKeyedChannelFactories = new Hashtable();
        public static TService GetObject<TService>(string endpointName)
        {
            Guard.ArgumentNotNullOrEmpty(endpointName, "endpointName");
            ChannelFactory<TService> channelFactory = null;
            if (!SunnyWcfHelper.endpointKeyedChannelFactories.ContainsKey(endpointName))
            {
                channelFactory = new ChannelFactory<TService>(endpointName);
                lock (SunnyWcfHelper.endpointKeyedChannelFactories.SyncRoot)
                {
                    if (!SunnyWcfHelper.endpointKeyedChannelFactories.ContainsKey(endpointName))
                    {
                        SunnyWcfHelper.endpointKeyedChannelFactories.Add(endpointName, channelFactory);
                    }
                }
            }
            if (channelFactory == null)
            {
                channelFactory = (SunnyWcfHelper.endpointKeyedChannelFactories[endpointName] as ChannelFactory<TService>);
            }
            return channelFactory.CreateChannel();
        }
        public static TResult Invoke<TService, TResult>(string endpointName, Func<TService, TResult> func)
        {
            TService @object = SunnyWcfHelper.GetObject<TService>(endpointName);
            TResult result;
            using (@object as IDisposable)
            {
                try
                {
                    result = func(@object);
                }
                catch (CommunicationException)
                {
                    (@object as ICommunicationObject).Abort();
                    throw;
                }
                catch (TimeoutException)
                {
                    (@object as ICommunicationObject).Abort();
                    throw;
                }
            }
            return result;
        }
        public static void Invoke<T>(string endpointName, Action<T> action)
        {
            T @object = SunnyWcfHelper.GetObject<T>(endpointName);
            using (@object as IDisposable)
            {
                try
                {
                    action(@object);
                }
                catch (CommunicationException)
                {
                    (@object as ICommunicationObject).Abort();
                    throw;
                }
                catch (TimeoutException)
                {
                    (@object as ICommunicationObject).Abort();
                    throw;
                }
            }
        }
        public static Exception HandleWcfCommonException(ICommunicationObject proxy, Exception ex)
        {
            if (ex is CommunicationException || ex is TimeoutException)
            {
                proxy.Abort();
            }
            return ex;
        }
    }
}
