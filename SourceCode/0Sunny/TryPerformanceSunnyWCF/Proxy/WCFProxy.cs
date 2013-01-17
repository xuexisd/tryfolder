using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sunny.Policy.WCF;
using Contract;
using Model;

namespace Proxy
{
    public class WCFProxy : SunnyWcfProxyIIS<IOperDB>, IOperDB
    {
        #region Create Channel
        public IOperDB GetInstance()
        {
            return this.GetObject();
        }
        #endregion

        public void Add(string name, string todowork)
        {
            GetInstance().Add(name, todowork);
        }

        public List<string> GetAllName()
        {
            return GetInstance().GetAllName();
        }

        public List<ModelTryPerformanceWCF> GetAllToJson()
        {
            return GetInstance().GetAllToJson();
        }
    }
}
