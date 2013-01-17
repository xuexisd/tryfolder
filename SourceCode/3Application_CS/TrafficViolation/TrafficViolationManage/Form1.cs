using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;

namespace TrafficViolationManage
{
    public partial class Form1 : Form
    {
        private string UnProcessed = @"http://service.cwddd.com/query/peccancy.shtml?cartype=02&carnumber={0}&carframe={1}&zt=0";
        private string Completed = @"http://service.cwddd.com/query/peccancy.shtml?cartype=02&carnumber={0}&carframe={1}&zt=1";
        private string PageCode = Encoding.Default.ToString();
        public Form1()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            ds.ReadXml(@"cars.xml");
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "NAME";
            listBox1.ValueMember = "VALUE";
            listBox1.ClearSelected();
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                Application.DoEvents();
                progressBar1.Value = 10;
                string currentCarP = HttpUtility.UrlEncode(listBox1.Text.Substring(0, 7).ToString()).ToUpper();
                string currentEngNum = listBox1.SelectedValue.ToString();
                #region Completed
                string urlCompleted = string.Format(Completed, currentCarP, currentEngNum);
                string pageContentCompleted = GetPage(urlCompleted);
                int numberCompleted = int.Parse(pageContentCompleted.Substring(pageContentCompleted.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                if (numberCompleted == 0)
                {
                    txtCompleted.Text = "【" + listBox1.Text.ToString().ToUpper() + "】亲，恭喜你^-^。你还未曾犯法过哦。请继续保持";
                }
                else
                {
                    txtCompleted.Text = "【" + listBox1.Text.ToString().ToUpper() + "】你一共有【" + numberCompleted.ToString() + "】条【已处理】的违章";
                }
                #endregion
                progressBar1.Value = 30;
                #region UnProcessed
                string urlUnProcessed = string.Format(UnProcessed, currentCarP, currentEngNum);
                string pageContentUnProcessed = GetPage(urlUnProcessed);
                int numberUnProcessed = int.Parse(pageContentUnProcessed.Substring(pageContentUnProcessed.IndexOf(" 的 小型汽车 共有  <font color=\"#d42e2f\">") + 34, 1));
                if (numberUnProcessed == 0)
                {
                    txtUnProcessed.Text = "【" + listBox1.Text.ToString().ToUpper() + "】亲，恭喜你^-^。你目前没有未处理的违法。请继续保持";
                }
                else
                {
                    txtUnProcessed.Text = "【" + listBox1.Text.ToString().ToUpper() + "】你一共有【" + numberUnProcessed.ToString() + "】条【未处理】的违章";
                }
                #endregion
                progressBar1.Value = 50;
                if ((numberCompleted + numberUnProcessed) > 0)
                {
                    tabControl1.Visible = true;
                    string webResultC = pageContentCompleted.Substring(pageContentCompleted.IndexOf("<ul class=\"result_list\">"), (pageContentCompleted.IndexOf("<div class=\"pages02\"><div class=\"pages\">") - pageContentCompleted.IndexOf("<ul class=\"result_list\">")));
                    string webResultU = pageContentUnProcessed.Substring(pageContentUnProcessed.IndexOf("<ul class=\"result_list\">"), (pageContentUnProcessed.IndexOf("<div class=\"pages02\"><div class=\"pages\">") - pageContentUnProcessed.IndexOf("<ul class=\"result_list\">")));
                    if (webResultC != "<ul class=\"result_list\"><li><h2></h2></li></ul>")
                    {
                        webResultCompleted.DocumentText = "<font size=\"2\">" + webResultC + "</font>";
                    }
                    else
                    {
                        webResultCompleted.DocumentText = "<b><font size=\"3\" color=\"blue\">亲，恭喜，暂时木有数据哦。。谢谢你的支持</font></b> <font size=\"2\" color=\"red\">by iheart-sunny</font>";
                    }
                    progressBar1.Value = 75;
                    if (webResultU != "<ul class=\"result_list\"><li><h2></h2></li></ul>")
                    {
                        webResultUnProcessed.DocumentText = "<font size=\"2\">" + webResultU + "</font>";
                    }
                    else
                    {
                        webResultUnProcessed.DocumentText = "<b><font size=\"3\" color=\"blue\">亲，恭喜，暂时木有数据哦。。谢谢你的支持</font></b> <font size=\"2\" color=\"red\">by iheart-sunny</font>";
                    }
                    progressBar1.Value = 100;
                }
                else
                {
                    tabControl1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }
        public string GetPage(string url)
        {
            string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            string pagehtml;
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (checkBox1.Checked)
            {
                WebProxy proxy = new WebProxy();
                proxy.Address = new Uri("http://proxy.cd.ncsi.com.cn:8080");
                proxy.Credentials = new NetworkCredential("yidong", "zh@zh1314..", "ncs");
                request.UseDefaultCredentials = true;
                request.Proxy = proxy;
            }
            request.UserAgent = userAgent;
            try
            {
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if ((response.ContentType != null) && (response.ContentType.IndexOf("charset") != -1))
                {
                    PageCode = GetCharType(response.ContentType.ToString());
                    reader = new StreamReader(stream, System.Text.Encoding.GetEncoding(PageCode));
                }
                else
                {
                    reader = new StreamReader(stream, System.Text.Encoding.Default);
                }
                pagehtml = reader.ReadToEnd();
            }
            catch
            {
                pagehtml = "页面无法访问或出现其他异常错误";
            }
            return pagehtml;
            //response.Close;
            //stream.Close;
            //reader.Close;
        }
        private string GetCharType(string tmp1)
        {
            string tmp = "";
            tmp = tmp1;
            int a = tmp.IndexOf("charset=") + 8;
            tmp = tmp.Substring(a, tmp.Length - a);
            return tmp;
        }
    }
}
