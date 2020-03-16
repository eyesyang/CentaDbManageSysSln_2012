using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CentaDbManageSys.BLL;

namespace CentaDbManageSys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string httpMethod = Request.HttpMethod;
            if(httpMethod.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                string userName = Request.Form["UserName"];
                string password = Request.Form["Password"];
                string validator = Request.Form["Validator"];
                MemberService memberService = new MemberService();
                if (memberService.Login(userName,password,validator))
                {
                    Response.Redirect("/main.aspx");
                    Response.End();
                }                
            }
        }
    }
}
