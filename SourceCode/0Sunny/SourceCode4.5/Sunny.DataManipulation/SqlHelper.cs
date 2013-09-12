using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Sunny.DataManipulation
{
    public class SqlHelper
    {
        public SqlConnection conn;
        public string CurrentConnectionDBstring;
        public static string CurrentKey;
        public static string CurrentIV;
        public void Initconn()
        {
            if (this.conn != null)
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                    this.conn.Dispose();
                }
                if (string.IsNullOrEmpty(this.CurrentConnectionDBstring))
                {
                    this.conn = new SqlConnection(SqlHelper.Decrypto(ConfigurationManager.AppSettings["sLeysiV/r+dcoq19ztaUfF7KmzmN/CU+JRPaVSu0PSQ="].ToString()));
                }
                else
                {
                    this.conn = new SqlConnection(SqlHelper.Decrypto(ConfigurationManager.AppSettings[this.CurrentConnectionDBstring].ToString()));
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.CurrentConnectionDBstring))
                {
                    this.conn = new SqlConnection(SqlHelper.Decrypto(ConfigurationManager.AppSettings["sLeysiV/r+dcoq19ztaUfF7KmzmN/CU+JRPaVSu0PSQ="].ToString()));
                }
                else
                {
                    this.conn = new SqlConnection(SqlHelper.Decrypto(ConfigurationManager.AppSettings[this.CurrentConnectionDBstring].ToString()));
                }
            }
        }
        public void Closeconn()
        {
            if (this.conn != null)
            {
                if (this.conn.State == ConnectionState.Open)
                {
                    this.conn.Close();
                    this.conn.Dispose();
                }
            }
        }
        public SqlCommand CreateCommand(string spName, params object[] parameterValues)
        {
            this.Initconn();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = spName;
            if (parameterValues != null && parameterValues.Length > 0)
            {
                SqlParameter[] spParameterSet = SqlHelperParameterCacheCN.GetSpParameterSet(this.conn, spName);
                SqlBaseHelperCN.AssignParameterValues(spParameterSet, parameterValues);
                SqlBaseHelperCN.AttachParameters(sqlCommand, spParameterSet);
            }
            return sqlCommand;
        }
        public object GetParameterValue(SqlCommand cmd, string outParValue)
        {
            string parameterName = "@" + outParValue;
            cmd.Connection = this.conn;
            this.conn.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters[parameterName].Value;
        }
        public DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteDataset(this.conn, spName, parameterValues);
        }
        public DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteDataset(this.conn, commandType, commandText);
        }
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteNonQuery(this.conn, commandType, commandText);
        }
        public int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteNonQuery(this.conn, spName, parameterValues);
        }
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteReader(this.conn, commandType, commandText);
        }
        public SqlDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            this.Initconn();
            return SqlBaseHelperCN.ExecuteReader(this.conn, spName, parameterValues);
        }
        public void FillDataset(string spName, DataTable dt)
        {
            this.Initconn();
            string[] tableNames = new string[]
			{
				dt.TableName
			};
            SqlBaseHelperCN.FillDataset(this.conn, spName, dt.DataSet, tableNames, null);
        }
        public void FillDataset(string spName, DataTable dt, params object[] parameterValues)
        {
            this.Initconn();
            string[] tableNames = new string[]
			{
				dt.TableName
			};
            SqlBaseHelperCN.FillDataset(this.conn, spName, dt.DataSet, tableNames, parameterValues);
        }
        public void FillDataset(SqlCommand command, DataTable dt)
        {
            this.Initconn();
            if (command.Parameters.Count > 0)
            {
                string[] tableNames = new string[]
				{
					dt.TableName
				};
                SqlParameter[] array = new SqlParameter[command.Parameters.Count];
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    array[i] = (SqlParameter)((ICloneable)command.Parameters[i]).Clone();
                }
                SqlBaseHelperCN.FillDataset(this.conn, command.CommandType, command.CommandText, dt.DataSet, tableNames, array);
            }
            else
            {
                string[] tableNames = new string[]
				{
					dt.TableName
				};
                SqlBaseHelperCN.FillDataset(this.conn, command.CommandText, dt.DataSet, tableNames, null);
            }
        }
        public void Update(string spName, DataTable dt)
        {
            this.Initconn();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlBaseHelperCN.ExecuteDatasetTypedParams(this.conn, spName, dt.Rows[i]);
            }
        }
        public void UpdateDataTable(DataTable dt, bool isdel)
        {
            this.Initconn();
            string[] array = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                array.SetValue(dt.Columns[i].ColumnName, i);
            }
            string str = dt.TableName.Substring(dt.TableName.IndexOf("_") + 1);
            string spName;
            if (isdel)
            {
                spName = "P_" + str + "_D";
            }
            else
            {
                spName = "P_" + str + "_U_Deleted";
            }
            SqlCommand insertCommand = SqlBaseHelperCN.CreateCommand(this.conn, "P_" + str + "_I", array);
            SqlCommand deleteCommand = SqlBaseHelperCN.CreateCommand(this.conn, spName, new string[]
			{
				array[0]
			});
            SqlCommand updateCommand = SqlBaseHelperCN.CreateCommand(this.conn, "P_" + str + "_U", array);
            SqlBaseHelperCN.UpdateDataset(insertCommand, deleteCommand, updateCommand, dt.DataSet, dt.TableName);
        }
        private static byte[] GetLegalKey()
        {
            SqlHelper.CurrentKey = "ii37y237ey2u3te2ur2!@#RTHY^&*fghfth*(DFGwydljI&*9&THYhrtGWER87r0";
            SymmetricAlgorithm symmetricAlgorithm = new RijndaelManaged();
            string text = SqlHelper.CurrentKey;
            symmetricAlgorithm.GenerateKey();
            byte[] key = symmetricAlgorithm.Key;
            int num = key.Length;
            if (text.Length > num)
            {
                text = text.Substring(0, num);
            }
            else
            {
                if (text.Length < num)
                {
                    text = text.PadRight(num, ' ');
                }
            }
            return Encoding.ASCII.GetBytes(text);
        }
        private static byte[] GetLegalIV()
        {
            SqlHelper.CurrentIV = "immsg!!@#!@$#$^$GTRGHTYHU&IAppDomainSetup&*YJTlskdjfsdkjxc@#0607";
            SymmetricAlgorithm symmetricAlgorithm = new RijndaelManaged();
            string text = SqlHelper.CurrentIV;
            symmetricAlgorithm.GenerateIV();
            byte[] iV = symmetricAlgorithm.IV;
            int num = iV.Length;
            if (text.Length > num)
            {
                text = text.Substring(0, num);
            }
            else
            {
                if (text.Length < num)
                {
                    text = text.PadRight(num, ' ');
                }
            }
            return Encoding.ASCII.GetBytes(text);
        }
        private static string Decrypto(string Source)
        {
            SymmetricAlgorithm symmetricAlgorithm = new RijndaelManaged();
            byte[] array = Convert.FromBase64String(Source);
            MemoryStream stream = new MemoryStream(array, 0, array.Length);
            symmetricAlgorithm.Key = SqlHelper.GetLegalKey();
            symmetricAlgorithm.IV = SqlHelper.GetLegalIV();
            ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(stream2);
            return streamReader.ReadToEnd();
        }
    }
}
