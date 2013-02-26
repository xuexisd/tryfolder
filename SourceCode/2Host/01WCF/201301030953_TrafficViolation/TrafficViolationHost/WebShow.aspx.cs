using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficViolationDA;
using TrafficViolationModel;

namespace TrafficViolationHost
{
    public partial class WebShow : System.Web.UI.Page
    {
        string strFormat = "<table align=\"left\" style=\"font-size:12px; width:100%;\"><tr><td colspan=\"2\" style=\"border: 1px solid #008000\"><b>{0}</b></td></tr><tr><td colspan=\"2\" style=\"border: 1px solid #008000\">违规时间：<font color=\"blue\">{1}</font></td></tr><tr><td colspan=\"2\" style=\"border: 1px solid #008000\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</td></tr><tr><td style=\"border: 1px solid #008000\">罚款：<font color=\"blue\">{3}</font>元</td><td style=\"border: 1px solid #008000\">记：<font color=\"blue\">{4}</font>分</td></tr></table>";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblResultU.Text = "";
            lblResultC.Text = "";
            SCParams scParams = new SCParams() { CarNumber = txtCarNumber.Text.Trim(), CarFrame = txtCarFrame.Text.Trim() };
            SCDA da = new SCDA();
            List<ViolationModel> listU = da.GetUnProcessedWebShow(scParams);
            List<ViolationModel> listC = da.GetCompletedWebShow(scParams);
            string stringU = "<font color=\"red\">未处理：</font><br />";
            string stringC = "<br /><font color=\"red\">已处理：</font><br />";
            int i = 1;
            int j = 1;
            foreach (ViolationModel u in listU)
            {
                stringU += i.ToString() + "<br />" + string.Format(strFormat, u.ViolationAddress, u.ViolationDateTime, u.ViolationContent, u.ViolationAmount, u.ViolationScore) + "<br /><br />";
                i++;
            }
            foreach (ViolationModel c in listC)
            {
                stringC += j.ToString() + "<br />" + string.Format(strFormat, c.ViolationAddress, c.ViolationDateTime, c.ViolationContent, c.ViolationAmount, c.ViolationScore) + "<br /><br />";
                j++;
            }
            if (stringU == "<font color=\"red\">未处理：</font><br />")
                lblResultU.Text = stringU + "恭喜，木有违章<br />";
            else
                lblResultU.Text = stringU;
            if (stringC == "<br /><font color=\"red\">已处理：</font><br />")
                lblResultC.Text = stringC + "恭喜，木有违章";
            else
                lblResultC.Text = stringC;
        }
    }
}