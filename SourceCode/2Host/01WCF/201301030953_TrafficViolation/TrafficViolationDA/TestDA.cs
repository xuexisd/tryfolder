using Sunny.DataManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using TrafficViolationContract;
using TrafficViolationModel;

namespace TrafficViolationDA
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestDA : ITest
    {
        public string returnTest(string id)
        {
            string retString = "";
            try
            {
                retString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + id.ToString();
            }
            catch (Exception ex)
            {
                retString = "[ERROR]";
            }
            return retString;
        }

        public List<TestModel> PostTest(TestModel postData)
        {
            List<TestModel> listModel = new List<TestModel>();
            try
            {
                for (int i = 1; i < 10; i++)
                {
                    TestModel retModel = new TestModel();
                    //retModel.postData = "From POST: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " [" + postData.postData.ToString() + "] ";
                    retModel.postData = postData.postData + " [ " + i.ToString() + " ] ";
                    listModel.Add(retModel);
                }
            }
            catch (Exception ex)
            {
                listModel = null;
            }
            return listModel;
        }

        public string returnTestBaseDB(string id)
        {
            string retString = "";
            try
            {
                SqlHelper helper = new SqlHelper();
                var sqlReader = helper.ExecuteReader("P_IsExist_Car", id);
                while (sqlReader.Read())
                {
                    retString = sqlReader[0].ToString().Equals("0") ? "NO" : "YES";
                }
                if (!sqlReader.IsClosed)
                    sqlReader.Close();

                return retString;
            }
            catch (Exception ex)
            {
                retString = "[ERROR] " + ex.Message;
            }
            return retString;
        }
    }
}
