using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficViolationDA;

namespace TrafficViolationHost
{
    public partial class UpdateRefreshDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                SCDA da = new SCDA();
                int i = da.UpdateRefreshDateToDefault(TextBox1.Text.Trim());
                if (i == 1)
                {
                    Label1.Text = "Success";
                }
                else
                {
                    Label1.Text = "Failed";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                SCDA da = new SCDA();
                int i = da.UpdateRefreshDateToDefault();
                if (i > 0)
                {
                    Label1.Text = "Success";
                }
                else
                {
                    Label1.Text = "Failed";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Trim().Equals("123123"))
            {
                SCDA da = new SCDA();
                GridView1.DataSource = da.GetAllCarInfo();
                GridView1.DataBind();
            }
        }
    }
}