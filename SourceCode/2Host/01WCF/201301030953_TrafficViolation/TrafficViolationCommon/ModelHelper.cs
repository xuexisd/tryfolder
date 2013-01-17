using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationCommon
{
    public class ModelHelper<T> where T : new()
    {
        public T SqlReaderToModelWithString(SqlDataReader sqlReader)
        {
            T model = new T();
            while (sqlReader.Read())
            {
                PropertyDescriptorCollection allProInfo = TypeDescriptor.GetProperties(typeof(T));
                //PropertyInfo[] allProInfo = typeof(T).GetProperties();
                foreach (PropertyDescriptor proInfo in allProInfo)
                {
                    proInfo.SetValue(model, Convert.ChangeType(sqlReader[proInfo.Name], proInfo.PropertyType));
                    //proInfo.SetValue(model, Convert.ChangeType(sqlReader[proInfo.Name], proInfo.PropertyType));
                }
            }
            if (!sqlReader.IsClosed)
                sqlReader.Close();
            return model;
        }
    }
}
