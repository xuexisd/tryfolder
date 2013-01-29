using Sunny.DataManipulation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TrafficViolationCommon;
using TrafficViolationContract;
using TrafficViolationModel;

namespace TrafficViolationDA
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SCDA : ISC
    {
        private string UnProcessedAddress = @"http://service.cwddd.com/query/peccancy.shtml?cartype=02&carnumber={0}&carframe={1}&zt=0";
        private string CompletedAddress = @"http://service.cwddd.com/query/peccancy.shtml?cartype=02&carnumber={0}&carframe={1}&zt=1";
        //查无此数据!
        //车架号后6位不匹配

        public List<SCModel> GetCompleted(SCParams scParams)
        {
            List<ViolationModel> listCompleted = new List<ViolationModel>();
            List<SCModel> retListCompleted = new List<SCModel>();
            try
            {
                string serverErrorMsg = "";
                CarInfoModel isExistCarInfoModel = GetCarInfoDetail(scParams.CarNumber, scParams.CarFrame);
                if (isExistCarInfoModel == null)
                {
                    isExistCarInfoModel = new CarInfoModel();
                    isExistCarInfoModel.CarFrame = scParams.CarFrame;
                    isExistCarInfoModel.CarNumber = scParams.CarNumber;
                    InsertCarInfo(isExistCarInfoModel);
                }
                else
                {
                    scParams.CarFrame = isExistCarInfoModel.CarFrame;
                }
                bool isRefresh = NeedRefresh(scParams.CarNumber, scParams.CarFrame, "C");
                if (isRefresh)
                {
                    GetAllCompleted(scParams, ref listCompleted);
                    if (listCompleted.Count > 0 && listCompleted[0].ViolationAddress == "车架号后6位不匹配")
                    {
                        serverErrorMsg = "车架号后6位不匹配";
                    }
                    else
                    {
                        foreach (ViolationModel currentModel in listCompleted)
                        {
                            InsertCarTrafficViolation(currentModel);
                        }
                        UpdateRefreshDate(scParams.CarNumber, "C");
                    }
                }
                if (string.IsNullOrEmpty(serverErrorMsg))
                {
                    List<ViolationModel> dbListViolationModel = GetViolation(scParams.CarNumber, scParams.CarFrame, "C");
                    foreach (ViolationModel currentModel in dbListViolationModel)
                    {
                        retListCompleted.Add(new SCModel()
                        {
                            ViolationAddress = currentModel.ViolationAddress,
                            ViolationDateTime = currentModel.ViolationDateTime,
                            ViolationAmount = currentModel.ViolationAmount.ToString(),
                            ViolationScore = currentModel.ViolationScore.ToString()
                        });
                    }
                }
                else
                {
                    retListCompleted.Add(new SCModel { ViolationAddress = "[ERROR]" + serverErrorMsg });
                }
            }
            catch (Exception ex)
            {
                retListCompleted.Add(new SCModel { ViolationAddress = "[ERROR]" + ex.Message });
            }
            return retListCompleted;
        }

        public List<SCModel> GetUnProcessed(SCParams scParams)
        {
            List<ViolationModel> listUnprocessed = new List<ViolationModel>();
            List<SCModel> retListUnprocessed = new List<SCModel>();
            try
            {
                string serverErrorMsg = "";
                CarInfoModel isExistCarInfoModel = GetCarInfoDetail(scParams.CarNumber, scParams.CarFrame);
                if (isExistCarInfoModel == null)
                {
                    isExistCarInfoModel = new CarInfoModel();
                    isExistCarInfoModel.CarFrame = scParams.CarFrame;
                    isExistCarInfoModel.CarNumber = scParams.CarNumber;
                    InsertCarInfo(isExistCarInfoModel);
                }
                else
                {
                    scParams.CarFrame = isExistCarInfoModel.CarFrame;
                }
                bool isRefresh = NeedRefresh(scParams.CarNumber, scParams.CarFrame, "U");
                if (isRefresh)
                {
                    GetAllUnProcessed(scParams, ref listUnprocessed);
                    if (listUnprocessed.Count > 0 && listUnprocessed[0].ViolationAddress == "车架号后6位不匹配")
                    {
                        serverErrorMsg = "车架号后6位不匹配";
                    }
                    else
                    {
                        foreach (ViolationModel currentModel in listUnprocessed)
                        {
                            InsertCarTrafficViolation(currentModel);
                        }
                        UpdateRefreshDate(scParams.CarNumber, "U");
                    }
                }
                if (string.IsNullOrEmpty(serverErrorMsg))
                {
                    List<ViolationModel> dbListViolationModel = GetViolation(scParams.CarNumber, scParams.CarFrame, "U");
                    foreach (ViolationModel currentModel in dbListViolationModel)
                    {
                        retListUnprocessed.Add(new SCModel()
                        {
                            ViolationAddress = currentModel.ViolationAddress,
                            ViolationDateTime = currentModel.ViolationDateTime,
                            ViolationAmount = currentModel.ViolationAmount.ToString(),
                            ViolationScore = currentModel.ViolationScore.ToString()
                        });
                    }
                }
                else
                {
                    retListUnprocessed.Add(new SCModel { ViolationAddress = "[ERROR]" + serverErrorMsg });
                }
            }
            catch (Exception ex)
            {
                retListUnprocessed.Add(new SCModel { ViolationAddress = "[ERROR]" + ex.Message });
            }
            return retListUnprocessed;
        }

        public void GetAllCompleted(SCParams scParams, ref List<ViolationModel> listCompleted)
        {
            HTTPHelper httpHelper = new HTTPHelper();
            ViolationModel model = new ViolationModel();
            string currentCarP = HttpUtility.UrlEncode(scParams.CarNumber).ToUpper();
            string urlCompleted = string.Format(CompletedAddress, currentCarP, scParams.CarFrame);
            string pageContentCompleted = httpHelper.GetPage(urlCompleted);

            if (!pageContentCompleted.Contains("车架号后6位不匹配"))
            {
                #region if there is only one page
                int numberCompleted = int.Parse(pageContentCompleted.Substring(pageContentCompleted.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                if (numberCompleted != 0)
                {
                    string[] completeds = pageContentCompleted.Split(new string[] { "<div class=\"result_r\"><h2>", "</h2><p>", "<font color=\"#d42e2f\">", "</font>元", "</font>分", "于 ", "，在" }, StringSplitOptions.None);
                    int j = 1;
                    if (completeds.Length > 0)
                    {
                        for (int i = 0; i < completeds.Length; i++)
                        {
                            if (!completeds[i].Contains("<")
                                && !completeds[i].Contains("/>")
                                && !completeds[i].Contains("罚款，记")
                                && !completeds[i].Contains("小型汽车")
                                )
                            {
                                switch (j)
                                {
                                    case 1:
                                        model.ViolationAddress = completeds[i];
                                        break;
                                    case 2:
                                        model.ViolationDateTime = completeds[i];
                                        break;
                                    case 3:
                                        model.ViolationContent = completeds[i];
                                        break;
                                    case 4:
                                        model.ViolationAmount = int.Parse(completeds[i]);
                                        break;
                                    case 5:
                                        model.ViolationScore = int.Parse(completeds[i]);
                                        break;
                                    default: break;
                                }
                                j++;
                                if (j > 5)
                                {
                                    model.CarNumber = scParams.CarNumber;
                                    model.ViolationStatus = "C";
                                    listCompleted.Add(model);
                                    model = new ViolationModel();
                                    j = 1;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region if there are some pages
                if (pageContentCompleted.Contains("条记录")
                        && pageContentCompleted.Contains("下一页"))
                {
                    int totalPage = int.Parse(pageContentCompleted.Substring(pageContentCompleted.IndexOf("条记录 "), 8).Substring(6, 2).Trim());
                    for (int pageNumber = 2; pageNumber <= totalPage; pageNumber++)
                    {
                        urlCompleted = string.Format(CompletedAddress + "&p=" + pageNumber.ToString(), currentCarP, scParams.CarFrame);
                        pageContentCompleted = httpHelper.GetPage(urlCompleted);
                        numberCompleted = int.Parse(pageContentCompleted.Substring(pageContentCompleted.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                        if (numberCompleted != 0)
                        {
                            string[] completeds = pageContentCompleted.Split(new string[] { "<div class=\"result_r\"><h2>", "</h2><p>", "<font color=\"#d42e2f\">", "</font>元", "</font>分", "于 ", "，在" }, StringSplitOptions.None);
                            int j = 1;
                            if (completeds.Length > 0)
                            {
                                for (int i = 0; i < completeds.Length; i++)
                                {
                                    if (!completeds[i].Contains("<")
                                        && !completeds[i].Contains("/>")
                                        && !completeds[i].Contains("罚款，记")
                                        && !completeds[i].Contains("小型汽车")
                                        )
                                    {
                                        switch (j)
                                        {
                                            case 1:
                                                model.ViolationAddress = completeds[i];
                                                break;
                                            case 2:
                                                model.ViolationDateTime = completeds[i];
                                                break;
                                            case 3:
                                                model.ViolationContent = completeds[i];
                                                break;
                                            case 4:
                                                model.ViolationAmount = int.Parse(completeds[i]);
                                                break;
                                            case 5:
                                                model.ViolationScore = int.Parse(completeds[i]);
                                                break;
                                            default: break;
                                        }
                                        j++;
                                        if (j > 5)
                                        {
                                            model.CarNumber = scParams.CarNumber;
                                            model.ViolationStatus = "C";
                                            listCompleted.Add(model);
                                            model = new ViolationModel();
                                            j = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                listCompleted.Add(new ViolationModel() { ViolationAddress = "车架号后6位不匹配" });
            }
        }

        public void GetAllUnProcessed(SCParams scParams, ref List<ViolationModel> listUnProcessed)
        {
            HTTPHelper httpHelper = new HTTPHelper();
            ViolationModel model = new ViolationModel();
            string currentCarP = HttpUtility.UrlEncode(scParams.CarNumber).ToUpper();
            string urlUnProcessed = string.Format(UnProcessedAddress, currentCarP, scParams.CarFrame);
            string pageContentUnProcessed = httpHelper.GetPage(urlUnProcessed);

            if (!pageContentUnProcessed.Contains("车架号后6位不匹配"))
            {
                #region if there is only one page
                int numberUnProcessed = int.Parse(pageContentUnProcessed.Substring(pageContentUnProcessed.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                if (numberUnProcessed != 0)
                {
                    string[] UnProcesseds = pageContentUnProcessed.Split(new string[] { "<div class=\"result_r\"><h2>", "</h2><p>", "<font color=\"#d42e2f\">", "</font>元", "</font>分", "于 ", "，在" }, StringSplitOptions.None);
                    int j = 1;
                    if (UnProcesseds.Length > 0)
                    {
                        for (int i = 0; i < UnProcesseds.Length; i++)
                        {
                            if (!UnProcesseds[i].Contains("<")
                                && !UnProcesseds[i].Contains("/>")
                                && !UnProcesseds[i].Contains("罚款，记")
                                && !UnProcesseds[i].Contains("小型汽车")
                                )
                            {
                                switch (j)
                                {
                                    case 1:
                                        model.ViolationAddress = UnProcesseds[i];
                                        break;
                                    case 2:
                                        model.ViolationDateTime = UnProcesseds[i];
                                        break;
                                    case 3:
                                        model.ViolationContent = UnProcesseds[i];
                                        break;
                                    case 4:
                                        model.ViolationAmount = int.Parse(UnProcesseds[i]);
                                        break;
                                    case 5:
                                        model.ViolationScore = int.Parse(UnProcesseds[i]);
                                        break;
                                    default: break;
                                }
                                j++;
                                if (j > 5)
                                {
                                    model.CarNumber = scParams.CarNumber;
                                    model.ViolationStatus = "U";
                                    listUnProcessed.Add(model);
                                    model = new ViolationModel();
                                    j = 1;
                                }
                            }
                        }
                    }
                }
                if (numberUnProcessed == 0)
                {
                    if (pageContentUnProcessed.Contains("查无此数据!"))
                    {
                        ClearUnViolation(scParams.CarNumber);
                    }
                }
                #endregion

                #region if there are some pages
                if (pageContentUnProcessed.Contains("条记录")
                        && pageContentUnProcessed.Contains("下一页"))
                {
                    int totalPage = int.Parse(pageContentUnProcessed.Substring(pageContentUnProcessed.IndexOf("条记录 "), 8).Substring(6, 2).Trim());
                    for (int pageNumber = 2; pageNumber <= totalPage; pageNumber++)
                    {
                        urlUnProcessed = string.Format(UnProcessedAddress + "&p=" + pageNumber.ToString(), currentCarP, scParams.CarFrame);
                        pageContentUnProcessed = httpHelper.GetPage(urlUnProcessed);
                        numberUnProcessed = int.Parse(pageContentUnProcessed.Substring(pageContentUnProcessed.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                        if (numberUnProcessed != 0)
                        {
                            string[] UnProcesseds = pageContentUnProcessed.Split(new string[] { "<div class=\"result_r\"><h2>", "</h2><p>", "<font color=\"#d42e2f\">", "</font>元", "</font>分", "于 ", "，在" }, StringSplitOptions.None);
                            int j = 1;
                            if (UnProcesseds.Length > 0)
                            {
                                for (int i = 0; i < UnProcesseds.Length; i++)
                                {
                                    if (!UnProcesseds[i].Contains("<")
                                        && !UnProcesseds[i].Contains("/>")
                                        && !UnProcesseds[i].Contains("罚款，记")
                                        && !UnProcesseds[i].Contains("小型汽车")
                                        )
                                    {
                                        switch (j)
                                        {
                                            case 1:
                                                model.ViolationAddress = UnProcesseds[i];
                                                break;
                                            case 2:
                                                model.ViolationDateTime = UnProcesseds[i];
                                                break;
                                            case 3:
                                                model.ViolationContent = UnProcesseds[i];
                                                break;
                                            case 4:
                                                model.ViolationAmount = int.Parse(UnProcesseds[i]);
                                                break;
                                            case 5:
                                                model.ViolationScore = int.Parse(UnProcesseds[i]);
                                                break;
                                            default: break;
                                        }
                                        j++;
                                        if (j > 5)
                                        {
                                            model.CarNumber = scParams.CarNumber;
                                            model.ViolationStatus = "U";
                                            listUnProcessed.Add(model);
                                            model = new ViolationModel();
                                            j = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                listUnProcessed.Add(new ViolationModel() { ViolationAddress = "车架号后6位不匹配" });
            }
        }

        //private int GetRandomNumber(int startNum, int endNum)
        //{
        //    Random ran = new Random();
        //    return ran.Next(startNum, endNum);
        //}

        private bool IsExistCar(string carNum)
        {
            bool retIsExist = false;
            SqlHelper helper = new SqlHelper();
            var sqlReader = helper.ExecuteReader("P_IsExist_Car", carNum);
            while (sqlReader.Read())
            {
                retIsExist = sqlReader[0].ToString().Equals("0") ? false : true;
            }
            if (!sqlReader.IsClosed)
                sqlReader.Close();

            return retIsExist;
        }

        private CarInfoModel GetCarInfoDetail(string carNumber, string carFrame)
        {
            SqlHelper helper = new SqlHelper();
            var sqlReader = helper.ExecuteReader("P_CarInfo_GetDetail_By_CarNum", carNumber, carFrame);
            CarInfoModel model = (new ModelHelper<CarInfoModel>()).SqlReaderToModelWithString(sqlReader);
            if (string.IsNullOrEmpty(model.CarNumber))
                model = null;
            return model;
        }

        private string InsertCarTrafficViolation(ViolationModel model)
        {
            SqlHelper helper = new SqlHelper();
            int isSucc = helper.ExecuteNonQuery("P_TrafficViolation_I", model.CarNumber, model.ViolationAddress, model.ViolationDateTime, model.ViolationAmount, model.ViolationScore, model.ViolationContent, model.ViolationStatus);
            return isSucc.ToString();
        }

        private void InsertCarInfo(CarInfoModel model)
        {
            SqlHelper helper = new SqlHelper();
            int isSucc = helper.ExecuteNonQuery("P_CarInfo_I", model.CarNumber, model.CarFrame, model.CarOwner, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));

        }

        private bool NeedRefresh(string carNumber, string carFrame, string ViolationStatus)
        {
            bool retIsRefresh = false;
            SqlHelper helper = new SqlHelper();
            if (ViolationStatus == "C")
            {
                var sqlReader = helper.ExecuteReader("P_Refresh_Date_C", carNumber, carFrame);
                DateTime dbDate = DateTime.Now;
                while (sqlReader.Read())
                {
                    dbDate = DateTime.Parse(sqlReader[0].ToString());
                }
                if (!sqlReader.IsClosed)
                    sqlReader.Close();
                if (DateTime.Parse(dbDate.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                    retIsRefresh = true;
                else
                    retIsRefresh = false;
            }
            if (ViolationStatus == "U")
            {
                var sqlReader = helper.ExecuteReader("P_Refresh_Date_U", carNumber, carFrame);
                DateTime dbDate = DateTime.Now;
                while (sqlReader.Read())
                {
                    dbDate = DateTime.Parse(sqlReader[0].ToString());
                }
                if (!sqlReader.IsClosed)
                    sqlReader.Close();
                if (DateTime.Parse(dbDate.ToShortDateString()) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                    retIsRefresh = true;
                else
                    retIsRefresh = false;
            }
            return retIsRefresh;
        }

        private List<ViolationModel> GetViolation(string carNumber, string carFrame, string ViolationStatus)
        {
            List<ViolationModel> listModel = new List<ViolationModel>();
            SqlHelper helper = new SqlHelper();
            DataSet ds = new DataSet();
            ds.Tables.Add("Violation");
            helper.FillDataset("P_TrafficViolation_Get_By_CarNum", ds.Tables["Violation"], carNumber, carFrame, ViolationStatus);
            for (int i = 0; i < ds.Tables["Violation"].Rows.Count; i++)
            {
                listModel.Add(new ViolationModel
                {
                    CarNumber = ds.Tables["Violation"].Rows[i]["CarNumber"].ToString(),
                    ViolationAddress = ds.Tables["Violation"].Rows[i]["ViolationAddress"].ToString(),
                    ViolationDateTime = ds.Tables["Violation"].Rows[i]["ViolationDateTime"].ToString(),
                    ViolationAmount = int.Parse(ds.Tables["Violation"].Rows[i]["ViolationAmount"].ToString()),
                    ViolationScore = int.Parse(ds.Tables["Violation"].Rows[i]["ViolationScore"].ToString()),
                    ViolationContent = ds.Tables["Violation"].Rows[i]["ViolationContent"].ToString(),
                    ViolationStatus = ds.Tables["Violation"].Rows[i]["ViolationStatus"].ToString(),
                    Created_Time = DateTime.Parse(ds.Tables["Violation"].Rows[i]["Created_Time"].ToString()),
                });
            }
            return listModel;
        }

        private void UpdateRefreshDate(string carNumber, string ViolationStatus)
        {
            SqlHelper helper = new SqlHelper();
            if (ViolationStatus == "C")
                helper.ExecuteNonQuery("P_CarInfo_U_RefreshDate_C", carNumber);
            if (ViolationStatus == "U")
                helper.ExecuteNonQuery("P_CarInfo_U_RefreshDate_U", carNumber);
        }

        public int UpdateRefreshDateToDefault(string carNumber)
        {
            SqlHelper helper = new SqlHelper();
            return helper.ExecuteNonQuery("P_Update_Refresh_Date", carNumber);
        }

        private void ClearUnViolation(string carNumber)
        {
            SqlHelper helper = new SqlHelper();
            helper.ExecuteNonQuery("P_TrafficViolation_Clear_U", carNumber);
        }
    }
}
