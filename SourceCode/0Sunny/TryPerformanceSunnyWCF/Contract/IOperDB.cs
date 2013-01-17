using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Model;
using System.ServiceModel.Web;

namespace Contract
{
    [ServiceContract]
    public interface IOperDB
    {
        [OperationContract]
        void Add(string name, string todowork);

        [OperationContract]
        List<string> GetAllName();

        [OperationContract]
        //[WebInvoke(ResponseFormat=WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.Wrapped)]
        [WebGet(UriTemplate = "",ResponseFormat =WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<ModelTryPerformanceWCF> GetAllToJson();
    }
}
