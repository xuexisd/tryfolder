using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Sunny.Policy.WCF
{
    public class SunnyWcfConsoleHost
    {
        public static void ServiceHostOpen(Type ServiceName)
        {
            ServiceHost _host = new ServiceHost(ServiceName);
            _host.Opened += delegate { Console.WriteLine("Service:[{0}]--->start... ...!", ServiceName.Name); };
            _host.Open();
        }
    }
}
