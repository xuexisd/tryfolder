using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proxy;

namespace WebApplication1
{
    public partial class WebJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WCFProxy proxy=new WCFProxy();
            var temp = proxy.GetAllToJson();
            Response.Write("");
        }
    }
}