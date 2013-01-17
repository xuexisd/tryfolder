using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrafficViolationCommon
{
    public class HTTPHelper
    {
        private string PageCode = Encoding.Default.ToString();
        public string GetPage(string url)
        {
            string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            string pagehtml;
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
        public string GetPageBaseProxy(string url, string proxyAddress, string proxyUserName, string proxyPWD, string proxyDomain)
        {
            string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)";
            string pagehtml;
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebProxy proxy = new WebProxy();
            proxy.Address = new Uri(proxyAddress);
            proxy.Credentials = new NetworkCredential(proxyUserName, proxyPWD, proxyDomain);
            request.UseDefaultCredentials = true;
            request.Proxy = proxy;
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
