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
    public interface ITest
    {
        [OperationContract]
        [WebGet(UriTemplate = "Test/returnTest?id={id}", BodyStyle = WebMessageBodyStyle.Bare
            , ResponseFormat = WebMessageFormat.Json)]
        string returnTest(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Test/PostTest",BodyStyle=WebMessageBodyStyle.Bare
            , ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<TestModel> PostTest(TestModel postData);

        [OperationContract]
        [WebGet(UriTemplate = "Test/returnTestBaseDB?id={id}", BodyStyle = WebMessageBodyStyle.Bare
            , ResponseFormat = WebMessageFormat.Json)]
        string returnTestBaseDB(string id);
    }
}
