using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationModel;

namespace TrafficViolationContract
{
    [ServiceContract]
    public interface ISC
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "SC/GetCompleted", Method = "POST"
            , BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<SCModel> GetCompleted(SCParams scParams);

        [OperationContract]
        [WebInvoke(UriTemplate = "SC/GetUnProcessed", Method = "POST"
           , BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<SCModel> GetUnProcessed(SCParams scParams);
    }
}
