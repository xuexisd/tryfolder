using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace Sunny.PageOperation
{
    public class SunnyWebPageHelper : IDisposable
    {

        #region 根据页面空间名填充对应的[表]的[行]的记录/Get values in this page and this values to columns on by one
        /// <summary>
        /// 获取某指定行的对应列在本页面中对应控件的值/Get values in this page and this values to columns on by one
        /// </summary>
        /// <param name="rows">指定行/Row</param>
        /// <param name="pageControl">输入:this</param>
        /// <returns></returns>
        public virtual DataRow FillRows(DataRow rows, Control pageControl)
        {
            Control tb = new Control();

            DataTable dt1 = rows.Table;

            string[] column = new string[dt1.Columns.Count];

            int a = 0;

            foreach (DataColumn dc in dt1.Columns)
            {

                column.SetValue(dc.ColumnName, a);

                a++;

            }

            for (int i = 0; i < column.Length; i++)
            {

                string temp = "";

                foreach (string vry in column.GetValue(i).ToString().Split('_'))
                {

                    temp += vry;

                }

                tb = pageControl.FindControl(temp);

                if (tb != null && tb is TextBox)
                {

                    TextBox tb1 = (TextBox)tb;
                    if (string.IsNullOrEmpty(tb1.Text.Trim().ToString()))
                    {
                        rows[column.GetValue(i).ToString()] = DBNull.Value;
                    }
                    else
                    {
                        rows[column.GetValue(i).ToString()] = Convert.ChangeType(tb1.Text.Trim(), dt1.Columns[temp].DataType);
                    }
                }

                else if (tb != null && tb is DropDownList)
                {

                    DropDownList tb1 = (DropDownList)tb;
                    if (string.IsNullOrEmpty(tb1.Text.ToString()))
                    {
                        rows[column.GetValue(i).ToString()] = DBNull.Value;
                    }
                    else
                    {
                        rows[column.GetValue(i).ToString()] = Convert.ChangeType(tb1.Text, dt1.Columns[temp].DataType);
                    }
                }

                else if (tb != null && tb is Label)
                {

                    Label tb1 = (Label)tb;

                    if (string.IsNullOrEmpty(tb1.Text.ToString()))
                    {
                        rows[column.GetValue(i).ToString()] = DBNull.Value;
                    }
                    else
                    {
                        rows[column.GetValue(i).ToString()] = Convert.ChangeType(tb1.Text, dt1.Columns[temp].DataType);
                    }

                }

            }

            return rows;

        }

        #endregion

        #region 根据页面(母版页)空间名填充对应的[表]的[行]的记录/Get values in this page and this values to columns on by one
        /// <summary>
        /// 获取某指定行的对应列在本页面中对应控件的值/Get values in this page and this values to columns on by one
        /// </summary>
        /// <param name="rows">指定行</param>
        /// <param name="pageControl">输入:this</param>
        /// <param name="ContentPlaceHolderID">此页面所承载的母版页里的ContentPlaceHolder的ID</param>
        /// <returns></returns>
        public virtual DataRow FillRows(DataRow rows, Control pageControl, string ContentPlaceHolderID)
        {
            Control tb = new Control();

            DataTable dt1 = rows.Table;

            string[] column = new string[dt1.Columns.Count];

            int a = 0;

            foreach (DataColumn dc in dt1.Columns)
            {

                column.SetValue(dc.ColumnName, a);

                a++;

            }

            for (int i = 0; i < column.Length; i++)
            {

                string temp = "";

                foreach (string vry in column.GetValue(i).ToString().Split('_'))
                {

                    temp += vry;

                }

                tb = pageControl.Page.Master.FindControl("ContentPlaceHolder1").FindControl(temp);

                if (tb != null && tb is TextBox)
                {

                    TextBox tb1 = (TextBox)tb;

                    rows[column.GetValue(i).ToString()] = tb1.Text.Trim();

                }

                else if (tb != null && tb is DropDownList)
                {

                    DropDownList tb1 = (DropDownList)tb;

                    rows[column.GetValue(i).ToString()] = tb1.Text;

                }

                else if (tb != null && tb is Label)
                {

                    Label tb1 = (Label)tb;

                    rows[column.GetValue(i).ToString()] = tb1.Text;

                }

            }

            return rows;

        }

        #endregion

        #region 根据对应的[表]的[行]的记录填充页面内容/Set values in this page and this values to columns on by one

        /// <summary>
        /// 获取某指定行的对应列在本页面中对应控件的值/Get values in this page and this values to columns on by one
        /// </summary>
        /// <param name="rows">指定行/Row</param>
        /// <returns></returns>
        public virtual void FillPages(DataRow rows, Control pageControl)
        {
            Control tb = new Control();

            DataTable dt1 = rows.Table;

            string[] column = new string[dt1.Columns.Count];

            int a = 0;

            foreach (DataColumn dc in dt1.Columns)
            {

                column.SetValue(dc.ColumnName, a);

                a++;

            }

            for (int i = 0; i < column.Length; i++)
            {

                string temp = "";

                foreach (string vry in column.GetValue(i).ToString().Split('_'))
                {

                    temp += vry;

                }

                tb = pageControl.FindControl(temp);

                if (tb != null && tb is TextBox)
                {

                    TextBox tb1 = (TextBox)tb;

                    tb1.Text = rows[column.GetValue(i).ToString()].ToString();

                }

                else if (tb != null && tb is DropDownList)
                {

                    DropDownList tb1 = (DropDownList)tb;

                    for (int da = 0; da < tb1.Items.Count; da++)
                    {
                        if (tb1.Items[da].Value.Equals(rows[column.GetValue(i).ToString()].ToString()))
                            tb1.Items[da].Selected = true;
                        else
                            tb1.Items[da].Selected = false;
                    }

                }

                else if (tb != null && tb is Label)
                {

                    Label tb1 = (Label)tb;

                    tb1.Text = rows[column.GetValue(i).ToString()].ToString();

                }

            }
        }

        #endregion

        #region IDisposable Members

        Component componect = new Component();
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    componect.Dispose();
                }

                // Release unmanaged resources

                m_disposed = true;
            }
        }

        ~SunnyWebPageHelper()
        {
            Dispose(false);
        }

        private bool m_disposed;


        #endregion
    }
}
