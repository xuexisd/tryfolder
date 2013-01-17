using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using CloudContactModel;

namespace CloudContactContract
{
    [ServiceContract]
    public interface IUserInfo
    {
        [OperationContract]
        [WebGet(UriTemplate = "UserInfo/GetUserInfoDetail?userEmail={userEmail}&userPWD={userPWD}", BodyStyle = WebMessageBodyStyle.Bare
            , ResponseFormat = WebMessageFormat.Json)]
        UserInfoModel GetUserInfoDetail(string userEmail, string userPWD);

        [OperationContract]
        [WebInvoke(UriTemplate = "UserInfo/NewUserInfo?userEmail={userEmail}&userPWD={userPWD}", Method = "POST"
            , BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        //[WebInvoke(UriTemplate = "UserInfo/NewUserInfo", Method = "POST"
        //    , BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        UserInfoModel NewUserInfo(string userEmail, string userPWD);

        [OperationContract]
        [WebGet(UriTemplate = "UserInfo/IsExistUserInfo?userEmail={userEmail}", BodyStyle = WebMessageBodyStyle.Bare
            , ResponseFormat = WebMessageFormat.Json)]
        int IsExistUserInfo(string userEmail);
    }
}
