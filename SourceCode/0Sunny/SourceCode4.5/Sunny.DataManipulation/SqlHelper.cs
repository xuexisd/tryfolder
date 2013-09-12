using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Sunny.DataManipulation
{
    /// <summary>
    /// operate MSSql database
    /// </summary>
    public class SqlHelper
    {
        #region public object

        /// <summary>
        /// definition SqlConnection object conn
        /// </summary>
        public SqlConnection conn;
        /// <summary>
        /// 选择性读取配置文件中的数据库连接字符串(多线连接)
        /// </summary>
        public string CurrentConnectionDBstring;

        #endregion

        #region public Method

        /// <summary>
        /// instance SqlConnection
        /// </summary>
        public void Initconn()
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
                if (string.IsNullOrEmpty(CurrentConnectionDBstring))
                    conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["SunnySqlDBString"].ToString());
                else
                    conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings[CurrentConnectionDBstring].ToString());
            }
            else
            {
                if (string.IsNullOrEmpty(CurrentConnectionDBstring))
                    conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["SunnySqlDBString"].ToString());
                else
                    conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings[CurrentConnectionDBstring].ToString());
            }

        }

        /// <summary>
        /// Close this SqlConnection
        /// </summary>
        public void Closeconn()
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        #endregion

        #region SqlBaseHelper

        #region CreateCommand
        /// <summary>
        /// Simplify the creation of a Sql command object by allowing
        /// a stored procedure and optional parameters to be provided
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCommand command = CreateCommand(conn, "AddCustomer", "CustomerID", "CustomerName");
        /// </remarks>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="sourceColumns">An array of string to be assigned as the source columns of the stored procedure parameters</param>
        /// <returns>A valid SqlCommand object</returns>
        public SqlCommand CreateCommand(string spName, params object[] parameterValues)
        {
            Initconn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            // 如果有参数值
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // 从缓存中加载存储过程参数,如果缓存中不存在则从数据库中检索参数信息并加载到缓存中. ()
                SqlParameter[] commandParameters = SqlHelperParameterCacheCN.GetSpParameterSet(conn, spName);
                // 给存储过程参数赋值
                SqlBaseHelperCN.AssignParameterValues(commandParameters, parameterValues);
                SqlBaseHelperCN.AttachParameters(cmd, commandParameters);
            }
            return cmd;

        }
        #endregion

        #region OutParameter

        public object GetParameterValue(SqlCommand cmd, string outParValue)
        {
            string outParamterValue = @"@" + outParValue;
            //cmd.Parameters.Add(new SqlParameter(outParamterValue,DBNull.Value));
            //cmd.Parameters[outParamterValue].Direction = ParameterDirection.Output;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters[outParamterValue].Value;
        }

        #endregion

        #region ExecuteDataset方法

        /// <summary>
        /// 执行指定数据库连接字符串的命令,直接提供参数值,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值.
        /// 示例: 
        ///  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteDataset(conn, spName, parameterValues);

        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或T-SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteDataset(conn, commandType, commandText);

        }

        /// <summary>
        /// 执行指定数据库连接对象的命令 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或T-SQL语句</param>
        /// <returns>返回影响的行数</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteNonQuery(conn, commandType, commandText);

        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,将对象数组的值赋给存储过程参数.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
        /// </remarks>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回影响的行数</returns>
        public int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteNonQuery(conn, spName, parameterValues);

        }

        /// <summary>
        /// 执行指定数据库连接对象的数据阅读器.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  SqlDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或T-SQL语句</param>
        /// <returns>返回包含结果集的SqlDataReader</returns>
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteReader(conn, commandType, commandText);

        }

        /// <summary>
        /// [调用者方式]执行指定数据库连接对象的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 此方法不提供访问存储过程输出参数和返回值参数.
        /// 示例:  
        ///  SqlDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="spName">T存储过程名</param>
        /// <param name="parameterValues">分配给存储过程输入参数的对象数组</param>
        /// <returns>返回包含结果集的SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            Initconn();
            return SqlBaseHelperCN.ExecuteReader(conn, spName, parameterValues);

        }

        #endregion ExecuteDataset数据集命令结束

        #region FillDataset 填充数据集

        /// <summary>
        /// 执行指定的存储过程,填充到指定的表中
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dt">要填充结果集的DataTable实例</param>
        public void FillDataset(string spName, DataTable dt)
        {
            Initconn();
            string[] tablename = { dt.TableName };
            SqlBaseHelperCN.FillDataset(conn, spName, dt.DataSet, tablename, null);
        }

        /// <summary>
        /// 执行指定的存储过程,填充到指定的表中
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="dt">要填充结果集的DataTable实例</param>
        /// <param name="parameterValues">存储过程所需要的参数</param>
        public void FillDataset(string spName, DataTable dt, params object[] parameterValues)
        {
            Initconn();
            string[] tablename = { dt.TableName };
            SqlBaseHelperCN.FillDataset(conn, spName, dt.DataSet, tablename, parameterValues);
        }

        /// <summary>
        /// 执行指定的存储过程,填充到指定的表中
        /// </summary>
        public void FillDataset(SqlCommand command, DataTable dt)
        {
            Initconn();
            if (command.Parameters.Count > 0)
            {
                string[] tablename = { dt.TableName };
                SqlParameter[] clonedParameters = new SqlParameter[command.Parameters.Count];
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    clonedParameters[i] = (SqlParameter)((ICloneable)command.Parameters[i]).Clone();
                }
                SqlBaseHelperCN.FillDataset(conn, command.CommandType, command.CommandText, dt.DataSet, tablename, clonedParameters);
            }
            else
            {
                string[] tablename = { dt.TableName };
                SqlBaseHelperCN.FillDataset(conn, command.CommandText, dt.DataSet, tablename, null);
            }
        }

        #endregion

        #endregion

        #region SqlHelper_DataSet

        /// <summary>
        /// 更新DataSet
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="dt">要更新的存储过程</param>
        /// <returns></returns>
        public void Update(string spName, DataTable dt)
        {
            Initconn();
            //SqlBaseHelperCN.ExecuteNonQuery(conn, spName, dt);
            for (int i = 0; i < dt.Rows.Count; i++)
                SqlBaseHelperCN.ExecuteDatasetTypedParams(conn, spName, dt.Rows[i]);
        }

        public void UpdateDataTable(DataTable dt, bool isdel)
        {
            Initconn();
            string[] clos = new string[dt.Columns.Count];
            string delString;
            for (int i = 0; i < dt.Columns.Count; i++)
                clos.SetValue(dt.Columns[i].ColumnName, i);
            string tableName = dt.TableName.Substring(dt.TableName.IndexOf("_") + 1);
            if (isdel)
                delString = "P_" + tableName + "_D";
            else
                delString = "P_" + tableName + "_U_Deleted";
            SqlCommand insertCommand = SqlBaseHelperCN.CreateCommand(conn, "P_" + tableName + "_I", clos);
            SqlCommand deleteCommand = SqlBaseHelperCN.CreateCommand(conn, delString, clos[0]);
            SqlCommand updateCommand = SqlBaseHelperCN.CreateCommand(conn, "P_" + tableName + "_U", clos);
            SqlBaseHelperCN.UpdateDataset(insertCommand, deleteCommand, updateCommand, dt.DataSet, dt.TableName);
        }

        #endregion

    }
}
