using System;
using System.Collections.Generic;
using System.Linq;
using CloudContactContract;
using CloudContactModel;
using CloudContactCommon;
using Sunny.DataManipulation;
using System.ServiceModel.Activation;

namespace CloudContactDA
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserInfoDA : IUserInfo
    {
        public UserInfoModel GetUserInfoDetail(string userEmail, string userPWD)
        {
            SqlHelper helper = new SqlHelper();
            var sqlReader = helper.ExecuteReader("P_UserInfo_Detail", userEmail, userPWD);
            UserInfoModel model = (new ModelHelper<UserInfoModel>()).SqlReaderToModelWithString(sqlReader);
            if (string.IsNullOrEmpty(model.UserEmail) && string.IsNullOrEmpty(model.UserPWD))
                model = null;
            return model;
        }

        public UserInfoModel NewUserInfo(string userEmail, string userPWD)
        {
            SqlHelper helper = new SqlHelper();
            UserInfoModel model = new UserInfoModel();

            if (IsExistUserInfo(userEmail) == 0)
            {
                helper.ExecuteNonQuery("P_UserInfo_I", userEmail, userPWD);

                var sqlReader = helper.ExecuteReader("P_UserInfo_Detail", userEmail, userPWD);
                model = (new ModelHelper<UserInfoModel>()).SqlReaderToModelWithString(sqlReader);
                return model;
            }
            else
            {
                model = null;
                return model;
            }
        }

        public int IsExistUserInfo(string userEmail)
        {
            int retIsExist = 99;
            SqlHelper helper = new SqlHelper();
            var sqlReader = helper.ExecuteReader("P_UserInfo_IsExist", userEmail);
            while (sqlReader.Read())
            {
                retIsExist = sqlReader[0].ToString().Equals("0") ? 0 : 1;
            }
            if (!sqlReader.IsClosed)
                sqlReader.Close();

            return retIsExist;
        }
    }
}
