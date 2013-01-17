using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sunny.DataManipulation;
using System.Data;
using Model;

namespace DB
{
    public class OperDB : Contract.IOperDB
    {
        public void Add(string name, string todowork)
        {
            SqlHelper helper = new SqlHelper();
            helper.ExecuteNonQuery("P_TryPerformanceWCF", name, todowork);
        }

        public List<string> GetAllName()
        {
            List<string> allName = new List<string>();
            SqlHelper helper = new SqlHelper();
            var Reader = helper.ExecuteReader("P_GetAllName");
            while (Reader.Read())
            {
                allName.Add(Reader["Name"].ToString());
            }
            if (!Reader.IsClosed)
                Reader.Close();
            return allName;
        }

        public List<ModelTryPerformanceWCF> GetAllToJson()
        {
            List<ModelTryPerformanceWCF> lists = new List<ModelTryPerformanceWCF>();
            SqlHelper helper = new SqlHelper();
            var Reader = helper.ExecuteReader("P_GetTOP10");
            while (Reader.Read())
            {
                lists.Add(new ModelTryPerformanceWCF()
                    {
                        ID = new Guid(Reader["ID"].ToString()),
                        Name = Reader["Name"].ToString(),
                        ToDoWork = Reader["ToDoWork"].ToString()
                    });
            }
            if (!Reader.IsClosed)
                Reader.Close();
            return lists;
        }
    }
}
